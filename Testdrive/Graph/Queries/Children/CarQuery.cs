using Testdrive.Graph.Repositories.Cars;
using Testdrive.Graph.Types;
using Testdrive.Models;

namespace Testdrive.Graph.Queries.Children
{
    public class CarQuery : BaseQuery<CarType, Car, int>
    {
        public CarQuery(ICarRepository repo) : base("car", "cars", repo) { }
    }
}
