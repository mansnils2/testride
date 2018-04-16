using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using TestRide.Graph.Repositories.Cars;
using TestRide.Graph.Repositories.Testdrives;
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
