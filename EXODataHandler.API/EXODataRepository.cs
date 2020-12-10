using EXODataHandler.API.Entities;
using EXODataHandler.Core;
using EXODataHandler.Parser;
using EXODataHandler.Parser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EXODataHandler.API
{
    /// <summary>
    /// Class that creates the API actions. Implements IEXODataRepository
    /// </summary>
    public class EXODataRepository : IEXODataRepository
    {
        /// <summary>
        /// IEXODataParser variable to validate file
        /// </summary>
        private readonly IEXODataParser parser;

        /// <summary>
        /// List of Planets
        /// </summary>
        private List<Planet> planets;

        /// <summary>
        /// List of Stars
        /// </summary>
        private List<Star> stars;

        /// <summary>
        /// Constroctor for EXODataRepository class
        /// </summary>
        public EXODataRepository()
        {
            parser = new EXODataParser();
        }

        /// <summary>
        /// Method used to create a DataSet with User's File path
        /// </summary>
        /// <param name="path">File's Path</param>
        /// <returns>Returns an APIResponse of Type EXODataSet</returns>
        public APIResponse<EXODataSet> ParseFile(string path)
        {
            EXODataSet result;

            //Validates the User's file
            APIResponse parserResponse = parser.TryParse(path, out EXOParsedData data);

            //Checks if the file validation was sucessfull...
            if (!parserResponse.Success)
            {
                //...if it wasn't Returns an APIResponse of Type EXODataSet
                //with respective error message
                return new APIResponse<EXODataSet>(parserResponse, null);
            }

            //Converts Planets in data into a List
            planets = data.Planets.ToList();

            //Converts Stars in data into a List
            stars = data.Stars.ToList();

            //Creates a new DataSet with the List of Planets and Stars
            result = new EXODataSet(data.DataStructure, new List<Planet>(planets),
                new List<Star>(stars));

            return new APIResponse<EXODataSet>(parserResponse, result);
        }

        /// <summary>
        /// Get all planets that match a set of criteria
        /// </summary>
        /// <param name="predicate">Predicate delegate that define a set of 
        /// criteria and determines object match</param>
        /// <param name="set">Optional list of planets to use as dataset</param>
        /// <returns> List of Planets that match the criteria</returns>
        public APIResponse<List<Planet>> GetPlanets(Func<Planet, bool> predicate,
            List<Planet> set)
        {
            //Trys to find a list with the desired criteria...
            try
            {
                List<Planet> result;

                //Checks if the theres a list to be used...
                if (set == null)
                    //...if not displays the planets list with the desired criteria
                    result = planets.Where(predicate).ToList();

                //Else displays the secondary list with the desired criteria
                else
                    result = set.Where(predicate).ToList();

                return new APIResponse<List<Planet>>(true, result);
            }
            //...and if it fails throws an exception
            //and displays an error message
            catch (Exception e)
            {
                return new APIResponse<List<Planet>>(false, null, e.Message);
            }
        }

        /// <summary>
        /// Get all stars that match a set of criteria
        /// </summary>
        /// <param name="predicate">Predicate delegate that define a set of 
        /// criteria and determines object match</param>
        /// <param name="set">Optional list of stars to use as dataset</param>
        /// <returns> List of Stars that match the criteria</returns>
        public APIResponse<List<Star>> GetStars(Func<Star, bool> predicate,
            List<Star> set)
        {
            //Trys to find a list with the desired criteria...
            try
            {
                List<Star> result;
                //Checks if the theres a list to be used...
                if (set == null)
                    //...if not displays the planets list with the desired criteria
                    result = stars.Where(predicate).ToList();
                //Else displays the secondary list with the desired criteria
                else
                    result = set.Where(predicate).ToList();

                return new APIResponse<List<Star>>(true, result);
            }
            //...and if it fails throws an exception
            //and displays an error message
            catch (Exception e)
            {
                return new APIResponse<List<Star>>(false, null, e.Message);
            }
        }

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
        public APIResponse<List<Planet>> OrderPlanets<T>(List<Planet> set,
            OrderByType orderByType,
            Func<Planet, T> keySelector,
            Func<Planet, T> secondaryKeySelector)
        {
            //Trys to find a list with the desired criteria...
            try
            {
                List<Planet> result;
                //Checks if the order is asceding...
                if (orderByType == OrderByType.Ascending)
                {
                    //Checks if there is as secondary criteria...
                    if (secondaryKeySelector == null)
                        //...if theres not orders it by the first criteria only
                        result = set.OrderBy(keySelector).ToList();
                    //else it uses the seconday criteria after the first one
                    else
                        result = set.OrderBy(keySelector)
                            .ThenBy(secondaryKeySelector).ToList();
                }
                //... else it defaults to descending
                else
                {
                    //Checks if there is as secondary criteria...
                    if (secondaryKeySelector == null)
                        //...if theres not orders it by the first criteria
                        result = set.OrderByDescending(keySelector).ToList();
                    else
                        result = set.OrderByDescending(keySelector)
                            .ThenByDescending(secondaryKeySelector).ToList();
                }

                return new APIResponse<List<Planet>>(true, result);
            }
            //...and if it fails throws an exception
            //and displays an error message
            catch (Exception e)
            {
                return new APIResponse<List<Planet>>(false, null, e.Message);
            }
        }


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
        public APIResponse<List<Star>> OrderStars<T>(List<Star> set,
            OrderByType orderByType,
            Func<Star, T> keySelector,
            Func<Star, T> secondaryKeySelector)
        {
            //Trys to find a list with the desired criteria...
            try
            {
                List<Star> result;
                //Checks if the order is asceding...
                if (orderByType == OrderByType.Ascending)
                {
                    //...if theres not orders it by the first criteria only
                    if (secondaryKeySelector == null)

                        //...if theres not orders it by the first criteria only
                        result = set.OrderBy(keySelector).ToList();

                    //else it uses the secondary criteria after the first one
                    else
                        result = set.OrderBy(keySelector)
                            .ThenBy(secondaryKeySelector).ToList();
                }
                //... else it defaults to descending
                else
                {
                    //Checks if there is as secondary criteria...
                    if (secondaryKeySelector == null)

                        //...if theres not orders it by the first criteria
                        result = set.OrderByDescending(keySelector).ToList();

                    //else it uses the secondary criteria after the first one
                    else
                        result = set.OrderByDescending(keySelector)
                            .ThenByDescending(secondaryKeySelector).ToList();
                }

                return new APIResponse<List<Star>>(true, result);
            }
            //...and if it fails throws an exception
            //and displays an error message
            catch (Exception e)
            {
                return new APIResponse<List<Star>>(false, null, e.Message);
            }
        }
    }
}
