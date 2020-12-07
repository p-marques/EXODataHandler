using EXODataHandler.Core;
using EXODataHandler.Parser.Entities;

namespace EXODataHandler.Parser
{
    public interface IEXODataParser
    {
        APIResponse TryParse(string fileName, out EXOParsedData data);
    }
}
