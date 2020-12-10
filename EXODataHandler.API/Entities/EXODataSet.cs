using EXODataHandler.Core;
using EXODataHandler.Parser.Entities;
using System.Collections.Generic;

namespace EXODataHandler.API.Entities
{
    /// <summary>
    /// Class that holds all planet's and star's information
    /// </summary>
    public class EXODataSet
    {
        /// <summary>
        /// Property used to read information from the Data Structure 
        /// </summary>
        public EXODataStructure DataStructure { get; }

        /// <summary>
        /// Property used to get the List of Planets 
        /// </summary>
        public List<Planet> Planets { get; }

        /// <summary>
        /// Property used to get the List of Stars
        /// </summary>
        public List<Star> Stars { get; }

        /// <summary>
        /// Property used to get the total of Planets in the Structure
        /// </summary>
        public int PlanetCount { get; }

        /// <summary>
        /// Property used to get the total of Stars in the Structure
        /// </summary>
        public int StarCount { get; }


        /// <summary>
        /// Constructor for the EXODataSet Class
        /// </summary>
        /// <param name="dataStructure">DataStructure created from the file
        /// information </param>
        /// <param name="planets"> List of Planets with all planets in the file
        /// and their respective information </param>
        /// <param name="stars">List of Stars with all stars in the file
        /// and their respective information</param>
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
