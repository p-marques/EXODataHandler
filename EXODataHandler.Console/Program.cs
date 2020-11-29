using EXODataHandler.Parser;
using EXODataHandler.Parser.Entities;
using EXODataHandler.Parser.Helpers;
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
                for (int i = 0; i < data.Planets.First.Value.DataFields.Count; i++)
                {
                    SConsole.WriteLine(data.Planets.First.Value.DataFields[i]);
                }
                
            }
            else
                SConsole.WriteLine($"Error! {result.Message}");
        }
    }
}
