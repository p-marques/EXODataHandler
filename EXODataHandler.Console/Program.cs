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
                /*//APIResponse<List<Planet>> r =
                //    repo.GetPlanets(x => x.DiscoveryYear > 2004 && x.Name.Contains("Kepler"));

                //SConsole.WriteLine("== Filters on entire data ==");
                //SConsole.WriteLine($"DiscoveryYear > 2004 and Name contains Kepler");
                //SConsole.WriteLine($"Found: {r.Result.Count}");

                //r = repo.GetPlanets(x => x.Host.Planets.Count > 5);

                //SConsole.WriteLine($"Stars with more than 5 planets");
                //SConsole.WriteLine($"Found: {r.Result.Count}");

                //r = repo.GetPlanets(x => x.Radius > 20f && x.Host.Mass > 2f);

                //SConsole.WriteLine($"Planet radius > 20 and Host mass > 2");
                //SConsole.WriteLine($"Found: {r.Result.Count}");

                //r = repo.GetPlanets(x => x.DiscoveryYear > 2004 && x.Name.Contains("Kepler"));

                //SConsole.WriteLine("== Cumulative filtering ==");
                //SConsole.WriteLine($"DiscoveryYear > 2004 and Name contains Kepler");
                //SConsole.WriteLine($"Found: {r.Result.Count}");

                //r = repo.GetPlanets(x => x.Host.Planets.Count > 5, r.Result);

                //SConsole.WriteLine($"Stars with more than 5 planets");
                //SConsole.WriteLine($"Found: {r.Result.Count}");

                //r = repo.GetPlanets(x => x.Radius > 20f && x.Host.Mass > 2f, r.Result);

                //SConsole.WriteLine($"Planet radius > 20 and Host mass > 2");
                //SConsole.WriteLine($"Found: {r.Result.Count}");

                //APIResponse<List<Star>> s =
                //    repo.GetStars(x => x.Radius > 40);

                //SConsole.WriteLine($"Stars with radius > 40");
                //SConsole.WriteLine($"Found: {s.Result.Count}");
                //SConsole.WriteLine($"Stars planet count:");

                //for (int i = 0; i < s.Result.Count; i++)
                //{
                //    SConsole.WriteLine($"\tStar #{i}: {s.Result[i].Planets.Count} planets");
                //}

                //s = repo.GetStars(x => x.Age > 12);

                //SConsole.WriteLine($"Stars with Age > 12");
                //SConsole.WriteLine($"Found: {s.Result.Count}");

                //APIResponse<List<Star>> ordered = repo.OrderStars(s.Result, OrderByType.Ascending, x => x.Age);

                //SConsole.WriteLine($">>> NOT ORDERED");
                //for (int i = 0; i < s.Result.Count; i++)
                //{
                //    Star a = s.Result[i];

                //    SConsole.WriteLine($"Name: {a.Name}, Age: {a.Age}");
                //}

                //SConsole.WriteLine($">>> ORDERED");
                //for (int i = 0; i < ordered.Result.Count; i++)
                //{
                //    Star a = ordered.Result[i];

                //    SConsole.WriteLine($"Name: {a.Name}, Age: {a.Age}");
                //}*/

                APIResponse<List<Planet>> a = repo.GetPlanets(x => x.EquilibriumTemperature > 2500);
                SConsole.WriteLine($"Found: {a.Result.Count}");

                SConsole.WriteLine("\n>>> NOT ORDERED");
                for (int i = 0; i < a.Result.Count; i++)
                {
                    Planet p = a.Result[i];

                    SConsole.WriteLine($"Name: {p.Name}, DiscMethod: {p.DiscoveryMethod}");
                }

                APIResponse<List<Planet>> p0 = repo.OrderPlanets(a.Result,
                    OrderByType.Descending, x => x.DiscoveryMethod);

                SConsole.WriteLine("\n>>> ORDERED WITH NO SENCONDARY KEY");
                for (int i = 0; i < p0.Result.Count; i++)
                {
                    Planet p = p0.Result[i];

                    SConsole.WriteLine($"Name: {p.Name}, DiscMethod: {p.DiscoveryMethod}");
                }

                APIResponse<List<Planet>> p1 = repo.OrderPlanets(a.Result, 
                    OrderByType.Descending, x => x.DiscoveryMethod, z => z.Name);

                SConsole.WriteLine("\n>>> ORDERED WITH SECONDARY KEY (NAME)");
                for (int i = 0; i < p1.Result.Count; i++)
                {
                    Planet p = p1.Result[i];

                    SConsole.WriteLine($"Name: {p.Name}, DiscMethod: {p.DiscoveryMethod}");
                }
            }
            else
                SConsole.WriteLine($"Error! {response.Message}");
        }
    }
}
