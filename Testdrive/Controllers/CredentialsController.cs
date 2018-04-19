using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TestRide.Controllers
{
    [Route("credentials")]
    public class CredentialsController : Controller
    {
        private readonly IConfiguration _config;

        public CredentialsController(IConfiguration config) => _config = config;

        [HttpGet("car-info")]
        public JsonResult GetCarInfoToken() => Json(new
        {
            token = _config.GetConnectionString("CarInfoToken"),
            url = _config.GetConnectionString("CarInfoRoute")
        });

        [HttpGet("pusher")]
        public JsonResult PusherCredentials() => Json(new
        {
            key = _config.GetConnectionString("PusherKey"),
            cluster = _config.GetConnectionString("PusherCluster")
        });
    }
}
