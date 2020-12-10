namespace EXODataHandler.Core
{
    /// <summary>
    /// Class that confirms if the API is able to read from the chosen file
    /// </summary>
    public class APIResponse
    {
        /// <summary>
        /// Property used to see if the API is able to read from
        /// the chosen file
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Property used to display user error message in case of failure
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Constructor for the API Class
        /// </summary>
        /// <param name="success"> Result from the TryParse method</param>
        /// <param name="message">Error message in case the Parsing fails</param>
        public APIResponse(bool success, string message = null)
        {
            Success = success;

            Message = message;
        }
    }
}
