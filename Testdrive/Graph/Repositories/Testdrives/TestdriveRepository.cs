using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRide.Data;
using TestRide.Extensions;
using TestRide.Models;
using TestRide.Services.PusherHandler;

namespace TestRide.Graph.Repositories.Testdrives
{
    public class TestdriveRepository : BaseRepository<Testdrive, int>, ITestdriveRepository
    {
        private readonly ApplicationDbContext _db;

        private readonly IHttpContextAccessor _http;

        private readonly IPusherHandler _pusher;

        public TestdriveRepository(
            ApplicationDbContext db, 
            IHttpContextAccessor http,
            IPusherHandler pusher) : base(db)
        {
            _db = db;
            _http = http;
            _pusher = pusher;
        }

        public Task<List<Testdrive>> MyTestdrives()
        {
            var user = _http.CurrentUser();
            return _db.Testdrives
                .AsNoTracking()
                .Include(t => t.User)
                .Include(t => t.Car)
                .Include(t => t.Customer)
                .Where(t => t.User.ExternalId == user)
                .ToListAsync();
        }

        public async Task<Response> AddTestdriveAsync(string licenseplate, string carName)
        {
            var car = _db.Cars.FirstOrDefault(c => c.Licenseplate == licenseplate);
            if (car == null)
            {
                car = new Car(licenseplate.ToUpper(), carName);
                await _db.Cars.AddAsync(car);
            }

            var user = await _db.Users.FirstOrDefaultAsync(u => u.ExternalId == _http.CurrentUser());
            if (user == null) return new Response("Privilegiehöjning krävs.", hasError: true);

            var testdrive = new Testdrive();
            testdrive.AddData(new Customer("Test Person", "test"), car, user);

            await _db.AddAsync(testdrive);
            var error = await _db.SaveChangesAsync() == 0;

            await _pusher.UpdateTestdrivesAsync();
            await _pusher.UpdateCustomersAsync();

            return new Response("Provkörningen lades till!", hasError: error);
        }
    }
}
