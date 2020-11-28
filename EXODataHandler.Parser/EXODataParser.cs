using EXODataHandler.Parser.Entities;
using System;
using System.IO;

namespace EXODataHandler.Parser
{
    public class EXODataParser : IEXODataParser
    {
        public EXODataParserResult TryParse(string fileName, out EXODataSet data)
        {
            data = null;

            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

                if (!path.EndsWith(".csv"))
                    throw new Exception("Wrong file format.\nExpecting .csv");

                // With C# 8.0 we don't need the braces
                using StreamReader sr = File.OpenText(path);

                string line = null;

                for (line = sr.ReadLine(); line != null; line = sr.ReadLine())
                {
                    line = line.Trim();

                    if (line.StartsWith('#') || string.IsNullOrEmpty(line))
                        continue;
                    else if (data == null)
                    {
                        EXODataStructure structure = EXODataStructure.Parse(line);

                        data = new EXODataSet(structure);
                    }

                    data.AddPlanet(line);
                }
            }
            catch (FileNotFoundException)
            {
                return new EXODataParserResult(false, "No file found.");
            }
            catch (DirectoryNotFoundException)
            {
                return new EXODataParserResult(false, "Directory not found.");
            }
            catch (Exception e)
            {
                return new EXODataParserResult(false, e.Message);
            }

            return new EXODataParserResult(true);
        }
    }
}
