using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
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
            services.AddMvc(config =>
                {
                    // only allow authenticated users
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();

                    config.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        public static void AddAuth0(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie()
                .AddOpenIdConnect("Auth0", options =>
                {
                    // Set the authority to your Auth0 domain
                    options.Authority = $"https://{configuration["Auth0:Domain"]}";

                    // Configure the Auth0 Client ID and Client Secret
                    options.ClientId = configuration["Auth0:ClientId"];
                    options.ClientSecret = configuration["Auth0:ClientSecret"];

                    // Set response type to code
                    options.ResponseType = "code";

                    // Configure the scope
                    options.Scope.Clear();
                    options.Scope.Add("openid");

                    // Set the callback path, so Auth0 will call back to http://localhost:5000/signin-auth0 
                    // Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard 
                    options.CallbackPath = new PathString("/signin-auth0");

                    // Configure the Claims Issuer to be Auth0
                    options.ClaimsIssuer = "Auth0";

                    options.Events = new OpenIdConnectEvents
                    {
                        // handle the logout redirection 
                        OnRedirectToIdentityProviderForSignOut = context =>
                        {
                            var logoutUri =
                                $"https://{configuration["Auth0:Domain"]}/v2/logout?client_id={configuration["Auth0:ClientId"]}";

                            var postLogoutUri = context.Properties.RedirectUri;
                            if (!string.IsNullOrEmpty(postLogoutUri))
                            {
                                if (postLogoutUri.StartsWith("/"))
                                {
                                    // transform to absolute
                                    var request = context.Request;
                                    postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase +
                                                    postLogoutUri;
                                }

                                logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
                            }

                            context.Response.Redirect(logoutUri);
                            context.HandleResponse();

                            return Task.CompletedTask;
                        }
                    };
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
