using EXODataHandler.Core;
using EXODataHandler.Parser.Entities;
using System;
using System.IO;

namespace EXODataHandler.Parser
{
    /// <summary>
    /// Class used to read user's file and create a data base with its contents
    /// </summary>
    public class EXODataParser : IEXODataParser
    {
        /// <summary>
        /// Method used to check for a valid file
        /// </summary>
        /// <param name="path">User's file path</param>
        /// <param name="data">Variable with Data informartion </param>
        /// <returns>Returns an APIResponse</returns>
        public APIResponse TryParse(string path, out EXOParsedData data)
        {
            data = null;

            //Trys to read the file...
            try
            {
                //Checks if its a valid file type...
                if (!path.EndsWith(".csv"))

                    //...if its not throws Wrong File Exception
                    throw new Exception("Wrong file format.\nExpecting .csv");

                // With C# 8.0 we don't need the braces
                using StreamReader sr = File.OpenText(path);

                string line = null;

                //Reads lines that arent null in the file
                for (line = sr.ReadLine(); line != null; line = sr.ReadLine())
                {
                    //Removes all white spaces from read line
                    line = line.Trim();

                    //Checks if the line starts with the "#" character
                    //or if its empty....
                    if (line.StartsWith('#') || string.IsNullOrEmpty(line))
                        //...if so it ignores them
                        continue;

                    //Checks if the current Data is empty...
                    else if (data == null)
                    {
                        //...creates a new structure with the correct lines...
                        EXODataStructure structure = EXODataStructure.Parse(line);


                        //...and creates a new DataStructure
                        data = new EXOParsedData(structure);

                        continue;
                    }

                    //Adds a planet with all its information to the DataStructure
                    data.AddPlanet(line);
                }
            }

            //...and if it fails it returns an APIResponse with
            // respective error message
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
