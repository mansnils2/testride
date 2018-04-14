using TestRide.Data;
using TestRide.Models;

namespace TestRide.Graph.Repositories.Cars
{
    public class CarRepository : BaseRepository<Car, int>, ICarRepository
    {
        public CarRepository(ApplicationDbContext db) : base(db) { }
    }
}
