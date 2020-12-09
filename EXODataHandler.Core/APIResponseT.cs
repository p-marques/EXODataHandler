namespace EXODataHandler.Core
{
    public class APIResponse<T> : APIResponse
    {
        public T Result { get; }

        public APIResponse(bool success, T result, string message = null) 
            : base(success, message)
        {
            Result = result;
        }

        public APIResponse(APIResponse originalResponse, T result)
            : base(originalResponse.Success, originalResponse.Message)
        {
            Result = result;
        }
    }
}
