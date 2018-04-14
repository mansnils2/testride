using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TestRide.Data;
using TestRide.Graph.GraphContext;
using TestRide.Graph.Mutations;
using TestRide.Graph.Mutations.Children;
using TestRide.Graph.Queries;
using TestRide.Graph.Queries.Children;
using TestRide.Graph.Repositories.Cars;
using TestRide.Graph.Repositories.Customers;
using TestRide.Graph.Repositories.Facilities;
using TestRide.Graph.Repositories.Testdrives;
using TestRide.Graph.Repositories.Users;
using TestRide.Services.Secrets;

namespace TestRide.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            // add connection to our own database
            services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddConfiguredMvc(this IServiceCollection services)
        {
            //services.AddMvc(config =>
            //{
            //    // only allow authenticated users
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();

            //    config.Filters.Add(new AuthorizeFilter(policy));
            //}).AddJsonOptions(options =>
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        public static void RequireHttps(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(options => { options.Filters.Add(new RequireHttpsAttribute()); });
        }

        public static void AddGraphQl(this IServiceCollection services)
        {
            // mutations
            services.AddTransient<TestdriveMutation>();

            services.AddTransient<ParentMutation>();

            // queries
            services.AddTransient<ParentQuery>();

            services.AddTransient<FacilityQuery>();

            services.AddTransient<UserQuery>();

            services.AddTransient<CarQuery>();

            services.AddTransient<CustomerQuery>();

            services.AddTransient<TestdriveQuery>();

            // Repositories
            services.AddTransient<IGraphContext, GraphContext>();

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IFacilityRepository, FacilityRepository>();

            services.AddTransient<ICarRepository, CarRepository>();

            services.AddTransient<ITestdriveRepository, TestdriveRepository>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }

        public static void AddInternalServices(this IServiceCollection services)
        {
            // we inject the httpcontext to fetch users backend
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            // Secret handler for Azure Key Vault
            services.AddTransient<ISecretHandler, SecretHandler>();
        }
    }
}
