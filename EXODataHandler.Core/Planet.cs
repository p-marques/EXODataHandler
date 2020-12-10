namespace EXODataHandler.Core
{
    /// <summary>
    /// Class that saves all the information regarding Planets.
    /// Extends Astronomical Body;
    /// </summary>
    public class Planet : AstronomicalBody
    {
        /// <summary>
        /// Property used to save the planet's DiscoveryMethod
        /// </summary>
        public string DiscoveryMethod { get; set; }

        /// <summary>
        /// Property used to save the planet's DiscoveryMethod
        /// </summary>
        public short? DiscoveryYear { get; set; }

        /// <summary>
        /// Property used to save the planet's Radius
        /// </summary>
        public float? Radius { get; set; }

        /// <summary>
        /// Property used to save the planet's Mass
        /// </summary>
        public float? Mass { get; set; }

        /// <summary>
        /// Property used to save the planet's OrbitalPeriod
        /// </summary>
        public float? OrbitalPeriod { get; set; }

        /// <summary>
        /// Property used to save the planet's EquilibriumTemperature
        /// </summary>
        public float? EquilibriumTemperature { get; set; }


        /// <summary>
        /// Property used to get the planet's host name
        /// </summary>
        public Star Host { get; }


        /// <summary>
        /// Constructor for the Planet class
        /// </summary>
        /// <param name="host">Planet's Host's name</param>
        /// <param name="name">Planet's Name </param>
        public Planet(Star host, string name) : base(name)
        {
            Host = host;
        }
    }
}
