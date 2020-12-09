namespace EXODataHandler.Core
{
    public class APIResponse
    {
        public bool Success { get; }

        public string Message { get; }

        public APIResponse(bool success, string message = null)
        {
            Success = success;

            Message = message;
        }
    }
}
