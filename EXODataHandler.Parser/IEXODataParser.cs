using EXODataHandler.Parser.Entities;

namespace EXODataHandler.Parser
{
    public interface IEXODataParser
    {
        EXODataParserResult TryParse(string fileName, out EXODataSet data);
    }
}
