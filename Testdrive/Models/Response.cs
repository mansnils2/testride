namespace TestRide.Models
{
    public class Response
    {
        public Response() { }

        public Response(string message, bool hasError)
        {
            Message = message;
            HasError = hasError;
        }

        public string Message { get; set; }

        public bool HasError { get; set; }
    }
}
