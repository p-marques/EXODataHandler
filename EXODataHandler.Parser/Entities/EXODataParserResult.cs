namespace EXODataHandler.Parser.Entities
{
    public struct EXODataParserResult
    {
        public bool Success { get; }

        public string Message { get; }

        public EXODataParserResult(bool success, string message = null)
        {
            Success = success;

            Message = message;
        }
    }
}
