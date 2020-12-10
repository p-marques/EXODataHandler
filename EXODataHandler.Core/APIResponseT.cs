namespace EXODataHandler.Core
{
    /// <summary>
    /// Classe used to check APIResponse of Type T. Implements APIResponse
    /// </summary>
    /// <typeparam name="T">Type passed to APIResponse</typeparam>
    public class APIResponse<T> : APIResponse
    {
        /// <summary>
        /// Property used to get result of the APIResponse with designed Type
        /// </summary>
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
