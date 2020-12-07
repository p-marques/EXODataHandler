using EXODataHandler.Core;
using EXODataHandler.Parser.Entities;
using System;
using System.IO;

namespace EXODataHandler.Parser
{
    public class EXODataParser : IEXODataParser
    {
        public APIResponse TryParse(string path, out EXOParsedData data)
        {
            data = null;

            try
            {
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

                        data = new EXOParsedData(structure);

                        continue;
                    }

                    data.AddPlanet(line);
                }
            }
            catch (FileNotFoundException)
            {
                return new APIResponse(false, "No file found.");
            }
            catch (DirectoryNotFoundException)
            {
                return new APIResponse(false, "Directory not found.");
            }
            catch (Exception e)
            {
                return new APIResponse(false, e.Message);
            }

            return new APIResponse(true);
        }
    }
}
