using EXODataHandler.Core;
using System.Collections.Generic;

namespace EXODataHandler.API.Entities
{
    public class EXODataSet
    {
        public List<Planet> Planets { get; }

        public List<Star> Stars { get; }

        public int PlanetCount { get; }

        public int StarCount { get; }

        public EXODataSet(List<Planet> planets, List<Star> stars)
        {
            Planets = planets;

            PlanetCount = Planets.Count;

            Stars = stars;

            StarCount = Stars.Count;
        }
    }
}
