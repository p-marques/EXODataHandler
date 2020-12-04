using System.Collections.Generic;

namespace EXODataHandler.Core
{
    public class Planet : AstronomicalBody
    {
        public string DiscoveryMethod { get; set; }
        public short? DiscoveryYear { get; set; }
        public float? PlanetRadius { get; set; }
        public float? PlanetMass { get; set; }
        public float? OrbitalPeriod { get; set; }
        public float? EquilibriumTemperature { get; set; }

        public object[] Data;

        public Star Host { get; }

        public Planet(Star host, string name) : base(name)
        {
            Host = host;
            Data = new object[] { DiscoveryMethod, DiscoveryYear, PlanetRadius, PlanetMass, OrbitalPeriod, EquilibriumTemperature };
        }
    }
}
