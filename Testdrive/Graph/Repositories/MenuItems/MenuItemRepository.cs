using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TestRide.Data;
using TestRide.Extensions;
using TestRide.Models;

namespace TestRide.Graph.Repositories.MenuItems
{
    public class MenuItemRepository : BaseRepository<MenuItem, int>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _http;

        public MenuItemRepository(ApplicationDbContext db, IHttpContextAccessor http) : base(db)
        {
            _db = db;
            _http = http;
        }

        public async Task<List<MenuItem>> MyMenuItems()
        {
            var user = _http.CurrentUser();

            var roles = await _db.Users
                .AsNoTracking()
                .Where(u => u.ExternalId == user)
                .Select(u => u.Roles)
                .FirstOrDefaultAsync();

            return await _db.MenuItems
                .AsNoTracking()
                .Where(m => (m.AllowedRoles & roles) != 0)
                .OrderBy(m => m.Order)
                .ToListAsync();
        }
    }
}
