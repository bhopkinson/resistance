namespace Resistance.Web.Hubs.Models
{
    public class Response
    {
        public Response()
        {
        }

        public Response(bool success, string errorMessage = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
