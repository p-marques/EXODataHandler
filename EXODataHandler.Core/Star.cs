using System.Collections.Generic;

namespace EXODataHandler.Core
{
    public class Star : AstronomicalBody
    {
        public float? StellarEffectiveTemperature { get; set; }
        public float? StellarRadius { get; set; }
        public float? StellarMass { get; set; }
        public float? StellarAge { get; set; }
        public float? StellarRotationSpeed { get; set; }
        public float? StellarRotationPeriod { get; set; }
        public float? SunDistance { get; set; }

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
