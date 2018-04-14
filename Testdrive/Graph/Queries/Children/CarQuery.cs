using TestRide.Graph.Repositories.Cars;
using TestRide.Graph.Types;
using TestRide.Models;

namespace TestRide.Graph.Queries.Children
{
    public class CarQuery : BaseQuery<CarType, Car, int>
    {
        public CarQuery(ICarRepository repo) : base("car", "cars", repo) { }
    }
}
