using System.Collections.Generic;

namespace EXODataHandler.Core
{
    public class Star : AstronomicalBody
    {
        public ICollection<Planet> Planets { get; }

        public Star(string name) : base(name)
        {
            Planets = new LinkedList<Planet>();
        }

        public void AddPlanet(Planet planetToAdd)
        {
            Planets.Add(planetToAdd);
        }
    }
}
