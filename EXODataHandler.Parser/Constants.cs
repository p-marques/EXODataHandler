namespace EXODataHandler.Parser
{
    internal static class Constants
    {
        public const string PlanetNameHeader = "pl_name";
        public const string HostNameHeader = "hostname";
        public const string DiscoveryMethod = "discoverymethod";
        public const string DiscoveryYear = "disc_year";
        public const string OrbitalPeriod = "pl_orbper";
        public const string PlanetRadius = "pl_rade";
        public const string PlanetMass = "pl_masse";
        public const string EquilibriumTemperature = "pl_eqt";
        public const string StellarEffectiveTemperature = "st_teff";
        public const string StellarRadius = "st_rad";
        public const string StellarMass = "st_mass";
        public const string StellarAge = "st_age";
        public const string StellarRotationSpeed = "st_vsin";
        public const string StellarRotationPeriod = "st_rotp";
        public const string SunDistance = "sy_dist";
        public const string RelevantHeaders = "pl_name,hostname," +
                                              "discoverymethod,disc_year," +
                                              "pl_orbper,pl_rade,pl_masse," +
                                              "pl_eqt,st_teff,st_rad," +
                                              "st_mass,st_age,st_vsin," +
                                              "st_rotp,sy_dist";


    }
}
