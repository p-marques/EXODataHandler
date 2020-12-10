using EXODataHandler.API.Entities;
using EXODataHandler.Core;
using System;
using System.Collections.Generic;

namespace EXODataHandler.API
{
    /// <summary>
    /// Interface used to manage data filters
    /// </summary>
    public interface IEXODataRepository
    {
        /// <summary>
        /// Converts the file's content into a DataSet with all planets and star
        /// information
        /// </summary>
        /// <param name="path">File's path used with the program</param>
        /// <returns>Returns a Data Set</returns>
        APIResponse<EXODataSet> ParseFile(string path);

        /// <summary>
        /// Get all planets that match a set of criteria
        /// </summary>
        /// <param name="predicate">Predicate delegate that define a set of 
        /// criteria and determines object match</param>
        /// <param name="set">Optional list of planets to use as dataset</param>
        /// <returns> List of Planets that match the criterial</returns>
        APIResponse<List<Planet>> GetPlanets(Func<Planet, bool> predicate,
            List<Planet> set = null);

        /// <summary>
        /// Get all stars that match a set of criteria
        /// </summary>
        /// <param name="predicate">Predicate delegate that define a set of 
        /// criteria and determines object match</param>
        /// <param name="set">Optional list of stars to use as dataset</param>
        /// <returns> List of stars that match the criterial</returns>
        APIResponse<List<Star>> GetStars(Func<Star, bool> predicate,
            List<Star> set = null);

        /// <summary>
        /// Orders Planet List
        /// </summary>
        /// <typeparam name="T">Type of the key returned by the keySelector</typeparam>
        /// <param name="set">list of planet to use as dataset</param>
        /// <param name="orderByType">Order in which the list is ordered</param>
        /// <param name="keySelector">Criteria by wich the list is ordered</param>
        /// <param name="secondaryKeySelector">Optional Secondary Criteria by which 
        /// the list is ordered in case of tie</param>
        /// <returns>List of Planets in the desired order</returns>
        APIResponse<List<Planet>> OrderPlanets<T>(List<Planet> set,
            OrderByType orderByType,
            Func<Planet, T> keySelector,
            Func<Planet, T> secondaryKeySelector = null);

        /// <summary>
        /// Orders Planet List
        /// </summary>
        /// <typeparam name="T">Type of the key returned by the keySelector</typeparam>
        /// <param name="set">list of Stars to use as dataset</param>
        /// <param name="orderByType">Order in which the list is ordered</param>
        /// <param name="keySelector">Criteria by wich the list is ordered</param>
        /// <param name="secondaryKeySelector">Optional Secondary Criteria by which 
        /// the list is ordered in case of tie</param>
        /// <returns>List of Stars in the desired order</returns>
        APIResponse<List<Star>> OrderStars<T>(List<Star> set,
            OrderByType orderByType,
            Func<Star, T> keySelector,
            Func<Star, T> secondaryKeySelector = null);
    }
}
