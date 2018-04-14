using Newtonsoft.Json;

namespace TestRide.Graph.Models
{
    public class GraphQlQuery
    {
        [JsonProperty("operationName")]
        public string OperationName { get; set; }

        [JsonProperty("namedQuery")]
        public string NamedQuery { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("variables")]
        public string Variables { get; set; }
    }
}
