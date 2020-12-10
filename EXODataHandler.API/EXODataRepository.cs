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

        public APIResponse<List<Planet>> GetPlanets(Func<Planet, bool> predicate,
            List<Planet> set)
        {
            try
            {
                List<Planet> result;

                if (set == null)
                    result = planets.Where(predicate).ToList();
                else
                    result = set.Where(predicate).ToList();

                return new APIResponse<List<Planet>>(true, result);
            }
            catch (Exception e)
            {
                return new APIResponse<List<Planet>>(false, null, e.Message);
            }
        }

        public APIResponse<List<Star>> GetStars(Func<Star, bool> predicate, 
            List<Star> set)
        {
            try
            {
                List<Star> result;

                if (set == null)
                    result = stars.Where(predicate).ToList();
                else
                    result = set.Where(predicate).ToList();

                return new APIResponse<List<Star>>(true, result);
            }
            catch (Exception e)
            {
                return new APIResponse<List<Star>>(false, null, e.Message);
            }
        }

        public APIResponse<List<Planet>> OrderPlanets<T>(List<Planet> set,
            OrderByType orderByType,
            Func<Planet, T> keySelector, 
            Func<Planet, T> secondaryKeySelector)
        {
            try
            {
                List<Planet> result;

                if (orderByType == OrderByType.Ascending)
                {
                    if (secondaryKeySelector == null)
                        result = set.OrderBy(keySelector).ToList();
                    else
                        result = set.OrderBy(keySelector)
                            .ThenBy(secondaryKeySelector).ToList();
                }
                else
                {
                    if (secondaryKeySelector == null)
                        result = set.OrderByDescending(keySelector).ToList();
                    else
                        result = set.OrderByDescending(keySelector)
                            .ThenByDescending(secondaryKeySelector).ToList();
                }

                return new APIResponse<List<Planet>>(true, result);
            }
            catch (Exception e)
            {
                return new APIResponse<List<Planet>>(false, null, e.Message);
            }
        }

        public APIResponse<List<Star>> OrderStars<T>(List<Star> set,
            OrderByType orderByType,
            Func<Star, T> keySelector,
            Func<Star, T> secondaryKeySelector)
        {
            try
            {
                List<Star> result;

                if (orderByType == OrderByType.Ascending)
                {
                    if (secondaryKeySelector == null)
                        result = set.OrderBy(keySelector).ToList();
                    else
                        result = set.OrderBy(keySelector)
                            .ThenBy(secondaryKeySelector).ToList();
                }
                else
                {
                    if (secondaryKeySelector == null)
                        result = set.OrderByDescending(keySelector).ToList();
                    else
                        result = set.OrderByDescending(keySelector)
                            .ThenByDescending(secondaryKeySelector).ToList();
                }

                return new APIResponse<List<Star>>(true, result);
            }
            catch (Exception e)
            {
                return new APIResponse<List<Star>>(false, null, e.Message);
            }
        }
    }
}
