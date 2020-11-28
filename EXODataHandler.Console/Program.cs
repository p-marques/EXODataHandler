using EXODataHandler.Parser;
using EXODataHandler.Parser.Entities;
using SConsole = System.Console;

namespace EXODataHandler.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IEXODataParser parser = new EXODataParser();

            var result = parser.TryParse(args[0], out EXODataSet data);

            if (result.Success)
            {
                SConsole.WriteLine("OK!");
            }
            else
                SConsole.WriteLine($"Error! {result.Message}");
        }
    }
}
