using EXODataHandler.Core;
using EXODataHandler.Parser.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EXODataHandler.Parser.Entities
{
    public class EXOParsedData
    {
        public LinkedList<Planet> Planets { get; }

        public LinkedList<Star> Stars { get; }

        public EXODataStructure DataStructure { get; }

        public EXOParsedData(EXODataStructure structure)
        {
            Planets = new LinkedList<Planet>();

            Stars = new LinkedList<Star>();

            DataStructure = structure;
        }

        internal void AddPlanet(string line)
        {
            string[] values = line.Split(',');
            int planetIndex = DataStructure.FindHeaderIndex(Constants.PlanetNameHeader);
            int starIndex = DataStructure.FindHeaderIndex(Constants.HostNameHeader);
            string planetName = values[planetIndex].Trim();
            string starName = values[starIndex].Trim();

            if (Planets.GetAstroByName(planetName) != null)
                throw new Exception("Repeated planet.");

            Star thisPlanetStar = Stars.GetAstroByName(starName);

            if (thisPlanetStar == null)
            {
                thisPlanetStar = new Star(starName);

                Stars.AddLast(thisPlanetStar);
            }

            Planet newPlanet = new Planet(thisPlanetStar, planetName);

            thisPlanetStar.AddPlanet(newPlanet);

            Planets.AddLast(newPlanet);

            HandleDataFields(newPlanet, values);
        }

        private void HandleDataFields(Planet planet, string[] values)
        {
            for (int k = 0; k < DataStructure.Headers.Count; k++)
            {
                SetDataField(DataStructure.Headers[k], planet, values);
            }
        }

        private void SetDataField(EXODataHeader header,Planet planet, string[] values)
        {
            string value = values[header.PositionIndex].Trim();

            if (string.IsNullOrEmpty(value))
                return;

            switch (header.Id)
            {
                case Constants.DiscoveryMethod:
                    planet.DiscoveryMethod = value;
                    break;
                case Constants.DiscoveryYear: 
                    planet.DiscoveryYear = short.Parse(value, 
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;
                case Constants.OrbitalPeriod:
                    planet.OrbitalPeriod = float.Parse(value, 
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;
                case Constants.PlanetRadius:
                    planet.Radius = float.Parse(value,
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;
                case Constants.PlanetMass:
                    planet.Mass = float.Parse(value,
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;
                case Constants.EquilibriumTemperature:
                    planet.EquilibriumTemperature = float.Parse(value, 
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;
                case Constants.StellarEffectiveTemperature:
                    planet.Host.EffectiveTemperature = float.Parse(value, 
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;
                case Constants.StellarRadius:
                    planet.Host.Radius = float.Parse(value, 
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;
                case Constants.StellarMass:
                    planet.Host.Mass = float.Parse(value, 
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;
                case Constants.StellarAge:
                    planet.Host.Age = float.Parse(value, 
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;
                case Constants.StellarRotationSpeed:
                    planet.Host.RotationSpeed = float.Parse(value,
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;
                case Constants.StellarRotationPeriod:
                    planet.Host.RotationPeriod = float.Parse(value, 
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;
                case Constants.SunDistance:
                    planet.Host.SunDistance = float.Parse(value, 
                                NumberStyles.Any, CultureInfo.InvariantCulture);
                    break;

            }
        }

    }
}
