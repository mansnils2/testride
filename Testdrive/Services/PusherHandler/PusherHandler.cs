using Ride.Library.Helpers.Extensions;
using Ride.Library.Services.PusherClient;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Ride.Core.Services.Secrets;

namespace Ride.Core.Services.PusherHandler
{
    public class PusherHandler : PusherClient, IPusherHandler
    {
        private readonly ISecretHandler _secrets;

        public PusherHandler(ISecretHandler secrets) : base(secrets) => _secrets = secrets;

        public async Task TriggerJobStateUpdateAsync(string user, int id, string status)
        {
            // initiate the client
            var pusher = GetClient();
            // push the job state update to all connected users on that channel
            await pusher.TriggerAsync("user-" + user.Caesar().ToLower(), "job-state-update", new {id, status});
        }

        public async Task TriggerJobStateUpdateAsync(IEnumerable<string> users, int id, string status)
        {
            // initiate the client
            var pusher = GetClient();
            // push the job state update to all connected users on that channel
            foreach (var user in users)
                await pusher.TriggerAsync("user-" + user.Caesar().ToLower(), "job-state-update", new {id, status});
        }

        public async Task TriggerNotificationAsync(string userId, string text, string url)
        {
            // initiate the client
            var pusher = GetClient();
            // push the notification out! every channel is defined
            // per user, and every user connects to an event-hub
            // and listens for incoming messages
            await pusher.TriggerAsync("user-" + userId.Caesar().ToLower(), "new-notification", new {text, url});
        }

        public async Task UpdatePersonalLeadsAsync(string userId)
        {
            // initiate the client
            var pusher = GetClient();
            await pusher.TriggerAsync("user-" + userId.Caesar().ToLower(), "update-leads", new { });
        }

        public async Task<HttpStatusCode> UpdateTestdrivesAsync(int? facilityId = null)
        {
            // initiate the client
            var pusher = GetClient();
            // trigger the message to the channel for all testdrives,
            var channel = !facilityId.HasValue ? "testdrives" : "testdrives-" + facilityId;
            var result = await pusher.TriggerAsync(channel, "new-testdrive", new { token = _secrets.TestdriveKey });
            return result.StatusCode;
        }

        public async Task<HttpStatusCode> UpdateChatForCarWithIdAsync(int id)
        {
            // initiate the client
            var pusher = GetClient();
            var result = await pusher.TriggerAsync("car-chat-" + id, "new-message", null);
            // Check statuscode
            return result.StatusCode;
        }
    }
}