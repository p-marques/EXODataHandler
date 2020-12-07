using EXODataHandler.API;
using EXODataHandler.API.Entities;
using EXODataHandler.Core;
using System;
using System.Collections.Generic;
using System.IO;
using SConsole = System.Console;

namespace EXODataHandler.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IEXODataRepository repo = new EXODataRepository();

            string fileName = args.Length > 0 ? args[0] : "exodata.csv";
            string path = Path.Combine(Environment
                    .GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            APIResponse<EXODataSet> response = repo.ParseFile(path);

            if (response.Success)
            {
                // Example
                APIResponse<List<Planet>> r =
                    repo.GetPlanets(x => x.DiscoveryYear == 2020 && x.Name.Contains("Kepler"));

                SConsole.WriteLine($"DiscoveryYear == 2020 and Name contains Kepler");
                SConsole.WriteLine($"Found: {r.Result.Count}");

                // Example
                r = repo.GetPlanets(x => x.Host.Planets.Count > 5);

                SConsole.WriteLine($"Stars with more than 5 planets");
                SConsole.WriteLine($"Found: {r.Result.Count}");

                // Example
                r = repo.GetPlanets(x => x.Radius > 20f && x.Host.Mass > 2f);

                SConsole.WriteLine($"Planet raius > 20 and Host mass > 2");
                SConsole.WriteLine($"Found: {r.Result.Count}");
            }
            else
                SConsole.WriteLine($"Error! {response.Message}");
        }
    }
}
