using EXODataHandler.Core;
using EXODataHandler.Parser.Helpers;
using System;
using System.Collections.Generic;

namespace EXODataHandler.Parser.Entities
{
    public class EXODataSet
    {
        public LinkedList<Planet> Planets { get; }

        public LinkedList<Star> Stars { get; }

        public EXODataStructure DataStructure { get; }

        public EXODataSet(EXODataStructure structure)
        {
            Planets = new LinkedList<Planet>();
            
            Stars = new LinkedList<Star>();

            DataStructure = structure;
        }

        internal void AddPlanet(string line)
        {
            string[] values = line.Split(',');
            int planetIndex = DataStructure.PlanetNameIndex;
            int starIndex = DataStructure.StarNameIndex;
            string planetName = values[planetIndex];
            string starName = values[starIndex];

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

            // TODO: Add data fields
        }
    }
}
