using GraphQL.Types;
using TestRide.Graph.Repositories.Cars;
using TestRide.Graph.Types;
using TestRide.Models;

namespace TestRide.Graph.Mutations.Children
{
    public class CarMutation : ObjectGraphType<CarType>
    {
        public CarMutation(ICarRepository repo)
        {
            Field<BooleanGraphType>(
                "addCar",
                resolve: context =>
                {
                    repo.Add(new Car());
                    return repo.SaveChangesAsync();
                });
        }
    }
}
