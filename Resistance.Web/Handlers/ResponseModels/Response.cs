namespace Resistance.Web.Handlers.ResponseModels
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
