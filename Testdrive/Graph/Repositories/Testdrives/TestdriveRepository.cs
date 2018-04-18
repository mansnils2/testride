using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TestRide.Data;
using TestRide.Models;

namespace TestRide.Graph.Repositories.Testdrives
{
    public class TestdriveRepository : BaseRepository<Testdrive, int>, ITestdriveRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _http;

        public TestdriveRepository(ApplicationDbContext db, IHttpContextAccessor http) : base(db)
        {
            _db = db;
            _http = http;
        }

        public Task<List<Testdrive>> MyTestdrives()
        {
            var user = _http.HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "name")
                ?.Value;

            return _db.Testdrives
                .AsNoTracking()
                .Include(t => t.User)
                .Include(t => t.Car)
                .Include(t => t.Customer)
                .Where(t => t.User.ExternalId == user)
                .ToListAsync();
        }
    }
}
