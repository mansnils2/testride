using System.Linq;
using GraphQL.Types;
using TestRide.Data;
using TestRide.Graph.Repositories.Testdrives;
using TestRide.Graph.Types;
using TestRide.Models;

namespace TestRide.Graph.Mutations.Children
{
    public class TestdriveMutation : ObjectGraphType<TestdriveType>
    {
        public TestdriveMutation(
            ITestdriveRepository repo, 
            ApplicationDbContext db)
        {
            Field<BooleanGraphType>(
                "addTestdrive",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "licenseplate" },
                    new QueryArgument<StringGraphType> { Name = "carName" }),
                resolve: context =>
                {
                    var licenseplate = context.GetArgument<string>("licenseplate");
                    var carName = context.GetArgument<string>("carName");

                    var car = db.Cars.FirstOrDefault(c => c.Licenseplate == licenseplate);
                    if (car == null)
                    {
                        car = new Car(licenseplate, carName);
                        db.Cars.Add(car);
                        db.SaveChanges();
                    }

                    var testdrive = new Testdrive {CarId = car.Id, CustomerId = 1, UserId = 1};
                    repo.Add(testdrive);

                    return repo.SaveChangesAsync();
                });
        }
    }
}
