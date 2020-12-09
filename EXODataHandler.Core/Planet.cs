namespace EXODataHandler.Core
{
    public class Planet : AstronomicalBody
    {
        public string DiscoveryMethod { get; set; }
        public short? DiscoveryYear { get; set; }
        public float? Radius { get; set; }
        public float? Mass { get; set; }
        public float? OrbitalPeriod { get; set; }
        public float? EquilibriumTemperature { get; set; }

        public Star Host { get; }

        public Planet(Star host, string name) : base(name)
        {
            Host = host;
        }
    }
}
