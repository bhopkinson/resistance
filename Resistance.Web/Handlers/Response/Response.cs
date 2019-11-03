namespace Resistance.Web.Handlers.Responses
{
    public class Response
    {
        public Response(bool success = true, string errorMessage = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
