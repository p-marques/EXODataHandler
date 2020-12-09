using System.Collections.Generic;

namespace EXODataHandler.Core
{
    public class Star : AstronomicalBody
    {
        public float? EffectiveTemperature { get; set; }
        public float? Radius { get; set; }
        public float? Mass { get; set; }
        public float? Age { get; set; }
        public float? RotationSpeed { get; set; }
        public float? RotationPeriod { get; set; }
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
