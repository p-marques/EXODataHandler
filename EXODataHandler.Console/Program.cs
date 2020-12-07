using EXODataHandler.Core;
using EXODataHandler.Parser;
using EXODataHandler.Parser.Entities;
using System.Collections.Generic;
using SConsole = System.Console;

namespace EXODataHandler.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IEXODataParser parser = new EXODataParser();

            var result = parser.TryParse(args.Length > 0 ? args[0] : "dummycsv.csv", out EXOParsedData data);

            if (result.Success)
            {
                LinkedListNode<Planet> node;

                for (node = data.Planets.First; node != null; node = node.Next)
                {
                    Planet p = node.Value;

                    SConsole.WriteLine($"Planet: {p.Name}");

                    SConsole.Write($"\tDiscovery Method: {p.DiscoveryMethod}, Discovery Year: {p.DiscoveryYear}, ");

                    SConsole.WriteLine($"Orbital Period: {p.OrbitalPeriod}, Radius: {p.PlanetRadius}, Mass: {p.PlanetMass}, Equilibrium Temperature: {p.EquilibriumTemperature}");

                    SConsole.WriteLine($"Host: {p.Host.Name}");

                    SConsole.Write($"\tEffective Temp: {p.Host.StellarEffectiveTemperature}, Radius: {p.Host.StellarRadius}, ");

                    SConsole.WriteLine($"Mass: {p.Host.StellarMass}, Age: {p.Host.StellarAge}, Rotation Speed: {p.Host.StellarRotationSpeed}, Rotation Period: {p.Host.StellarRotationPeriod}, Distance To Sun: {p.Host.SunDistance}");

                    SConsole.WriteLine("------");

                }

            }
            else
                SConsole.WriteLine($"Error! {result.Message}");
        }


    }
}
