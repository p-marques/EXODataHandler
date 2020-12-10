using EXODataHandler.Core;
using EXODataHandler.Parser.Entities;

namespace EXODataHandler.Parser
{
    /// <summary>
    /// Interface used to check if the file is valid 
    /// </summary>
    public interface IEXODataParser
    {
        /// <summary>
        /// Method used to create Data from the used file´s path
        /// </summary>
        /// <param name="path">File's Path</param>
        /// <param name="data">Data created from the file</param>
        /// <returns>returns an APIResponse with the result</returns>
        APIResponse TryParse(string path, out EXOParsedData data);
    }
}
