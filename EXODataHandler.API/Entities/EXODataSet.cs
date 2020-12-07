using EXODataHandler.Core;
using EXODataHandler.Parser.Entities;
using System.Collections.Generic;

namespace EXODataHandler.API.Entities
{
    public class EXODataSet
    {
        public EXODataStructure DataStructure { get; }

        public List<Planet> Planets { get; }

        public List<Star> Stars { get; }

        public int PlanetCount { get; }

        public int StarCount { get; }

        public EXODataSet(EXODataStructure dataStructure, List<Planet> planets, 
            List<Star> stars)
        {
            DataStructure = dataStructure;

            Planets = planets;

            PlanetCount = Planets.Count;

            Stars = stars;

            StarCount = Stars.Count;
        }
    }
}
