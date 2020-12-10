using System.Collections.Generic;

namespace EXODataHandler.Core
{
    /// <summary>
    /// Class used to save all Star related information. Extends AstronomicalBody
    /// </summary>
    public class Star : AstronomicalBody
    {
        /// <summary>
        /// Prperty used to save the Star's EffectiveTemperature
        /// </summary>
        public float? EffectiveTemperature { get; set; }

        /// <summary>
        /// Prperty used to save the Star's Radius
        /// </summary>
        public float? Radius { get; set; }

        /// <summary>
        /// Prperty used to save the Star's Mass
        /// </summary>
        public float? Mass { get; set; }

        /// <summary>
        /// Prperty used to save the Star's Age
        /// </summary>
        public float? Age { get; set; }

        /// <summary>
        /// Prperty used to save the Star's RotationSpeed
        /// </summary>
        public float? RotationSpeed { get; set; }

        /// <summary>
        /// Prperty used to save the Star's RotationPeriod
        /// </summary>
        public float? RotationPeriod { get; set; }

        /// <summary>
        /// Prperty used to save theStar's SunDistance
        /// </summary>
        public float? SunDistance { get; set; }

        /// <summary>
        /// Property used to get the collection of planets
        /// </summary>
        public ICollection<Planet> Planets { get; }


        /// <summary>
        /// Constructor for the Star class
        /// </summary>
        /// <param name="name">Name of the Star</param>
        public Star(string name) : base(name)
        {
            Planets = new LinkedList<Planet>();
        }

        /// <summary>
        /// Method used to Add a planet to the new LinkedList
        /// </summary>
        /// <param name="planetToAdd">Planet to be added to List</param>
        public void AddPlanet(Planet planetToAdd)
        {
            Planets.Add(planetToAdd);
        }
    }
}
