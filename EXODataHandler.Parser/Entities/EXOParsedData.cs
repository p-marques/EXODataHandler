using EXODataHandler.Core;
using EXODataHandler.Parser.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EXODataHandler.Parser.Entities
{
    /// <summary>
    /// Class used to save the data in the DataStructure
    /// </summary>
    public class EXOParsedData
    {
        /// <summary>
        /// Property used to get the LinkedList of Planets
        /// </summary>
        public LinkedList<Planet> Planets { get; }

        /// <summary>
        /// Property used to get the LinkedList of Stars
        /// </summary>
        public LinkedList<Star> Stars { get; }

        /// <summary>
        /// Property used to the the LinkedList of Planets
        /// </summary>
        public EXODataStructure DataStructure { get; }


        /// <summary>
        /// Constructor for the EXOParsedData class
        /// </summary>
        /// <param name="structure">Structure where Data will be stored</param>
        public EXOParsedData(EXODataStructure structure)
        {
            Planets = new LinkedList<Planet>();

            Stars = new LinkedList<Star>();

            DataStructure = structure;
        }


        /// <summary>
        /// Method used to save Planet's Data
        /// </summary>
        /// <param name="line"></param>
        internal void AddPlanet(string line)
        {

            string[] values = line.Split(',');
            int planetIndex = DataStructure.FindHeaderIndex(Constants.PlanetNameHeader);
            int starIndex = DataStructure.FindHeaderIndex(Constants.HostNameHeader);
            string planetName = values[planetIndex].Trim();
            string starName = values[starIndex].Trim();


            //Checks if the List alreay has the current planet...
            if (Planets.GetAstroByName(planetName) != null)

                //...and throws a Repeated Planet Exception 
                throw new Exception("Repeated planet.");

           
            Star thisPlanetStar = Stars.GetAstroByName(starName);

            //Checks if the planet's star doensn't exist....
            if (thisPlanetStar == null)
            {
                //...and adds it if it doesn't
                thisPlanetStar = new Star(starName);

                Stars.AddLast(thisPlanetStar);
            }

            //Creates a new planet
            Planet newPlanet = new Planet(thisPlanetStar, planetName);

            //Adds it to the Star host
            thisPlanetStar.AddPlanet(newPlanet);

            //Adds the new planet to the list
            Planets.AddLast(newPlanet);

            //Sets the new planet's data
            HandleDataFields(newPlanet, values);
        }

        /// <summary>
        /// Method used to manage the data fields of a Planet
        /// </summary>
        /// <param name="planet">Variable of Type Planet</param>
        /// <param name="values">Array with data in the current file's line</param>
        private void HandleDataFields(Planet planet, string[] values)
        {
            //for the amount of headers in the structures, sets the data
            //for the corresponding header
            for (int k = 0; k < DataStructure.Headers.Count; k++)
            {
                SetDataField(DataStructure.Headers[k], planet, values);
            }
        }

        /// <summary>
        /// Method used to Set the Planet's Information into the corresponding
        /// Data fields
        /// </summary>
        /// <param name="header">Data Header</param>
        /// <param name="planet">Planet</param>
        /// <param name="values">Data Header information</param>
        private void SetDataField(EXODataHeader header,Planet planet, string[] values)
        {
            string value = values[header.PositionIndex].Trim();

            //if the data field is empty doesn't add it
            if (string.IsNullOrEmpty(value))
                return;

            //Verifys which DataField is going to be set based on the Header's ID
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
