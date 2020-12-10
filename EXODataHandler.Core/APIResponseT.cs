namespace EXODataHandler.Core
{
    /// <summary>
    /// Class used to check APIResponse of Type T. Implements APIResponse
    /// </summary>
    /// <typeparam name="T">Type passed to APIResponse</typeparam>
    public class APIResponse<T> : APIResponse
    {
        /// <summary>
        /// Property used to get Result object of the API call"
        /// </summary>
        public T Result { get; }

        /// <summary>
        /// Constructor for the Generic APIResponse class
        /// </summary>
        /// <param name="success"> Result from the TryParse method</param>
        /// <param name="result">Result object of the API call</param>
        /// <param name="message">Error message in case the Parsing fails</param>
        public APIResponse(bool success, T result, string message = null) 
            : base(success, message)
        {
            Result = result;
        }

        /// <summary>
        /// Constructor for the Generic APIResponse class
        /// </summary>
        /// <param name="originalResponse">Result of a non-generic APIResponse 
        /// call</param>
        /// <param name="result">Result object of the API call</param>
        public APIResponse(APIResponse originalResponse, T result)
            : base(originalResponse.Success, originalResponse.Message)
        {
            Result = result;
        }
    }
}
