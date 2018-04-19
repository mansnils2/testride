using Microsoft.AspNetCore.Http;
using System.Linq;

namespace TestRide.Extensions
{
    public static class HttpContextExtensions
    {
        public static string CurrentUser(this IHttpContextAccessor http) => http.HttpContext.User.Claims
            .FirstOrDefault(c => c.Type == "name")
            ?.Value;
    }
}