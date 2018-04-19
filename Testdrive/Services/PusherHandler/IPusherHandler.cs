using System.Net;
using System.Threading.Tasks;

namespace TestRide.Services.PusherHandler
{
    public interface IPusherHandler
    {
        Task<HttpStatusCode> UpdateTestdrivesAsync();
        Task<HttpStatusCode> UpdateCustomersAsync();
    }
}