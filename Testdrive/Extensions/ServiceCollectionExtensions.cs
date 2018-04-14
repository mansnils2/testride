using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Testdrive.Data;
using Testdrive.Graph.GraphContext;
using Testdrive.Graph.Mutations;
using Testdrive.Graph.Queries;
using Testdrive.Graph.Queries.Children;
using Testdrive.Graph.Repositories.Cars;
using Testdrive.Graph.Repositories.Customers;
using Testdrive.Graph.Repositories.Facilities;
using Testdrive.Graph.Repositories.Testdrives;
using Testdrive.Graph.Repositories.Users;
using Testdrive.Services.Secrets;

namespace Testdrive.Extensions
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
            services.AddMvc(config =>
            {
                // only allow authenticated users
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        public static void AddBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var domain = $"https://{configuration["Auth0:Domain"]}/";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = configuration["Auth0:ApiIdentifier"];
            });
        }

        public static void RequireHttps(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(options => { options.Filters.Add(new RequireHttpsAttribute()); });
        }

        public static void AddGraphQl(this IServiceCollection services)
        {
            // mutations
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
