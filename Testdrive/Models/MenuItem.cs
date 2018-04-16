using TestRide.Graph.Models;

namespace TestRide.Models
{
    public class MenuItem : IEntity<int>
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public Roles AllowedRoles { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }
    }
}
