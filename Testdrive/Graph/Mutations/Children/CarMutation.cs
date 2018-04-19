using GraphQL.Types;
using TestRide.Graph.Repositories.Cars;
using TestRide.Graph.Types;

namespace TestRide.Graph.Mutations.Children
{
    public class CarMutation : ObjectGraphType<CarType>
    {
        public CarMutation(ICarRepository repo)
        {
            
        }
    }
}
