using Testdrive.Data;
using Testdrive.Models;

namespace Testdrive.Graph.Repositories.Cars
{
    public class CarRepository : BaseRepository<Car, int>, ICarRepository
    {
        public CarRepository(ApplicationDbContext db) : base(db) { }
    }
}
