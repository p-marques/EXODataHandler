using EXODataHandler.API.Entities;
using EXODataHandler.Core;
using EXODataHandler.Parser;
using EXODataHandler.Parser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EXODataHandler.API
{
    public class EXODataRepository : IEXODataRepository
    {
        private readonly IEXODataParser parser;

        private List<Planet> planets;

        private List<Star> stars;

        public EXODataRepository()
        {
            parser = new EXODataParser();
        }

        public APIResponse<EXODataSet> ParseFile(string path)
        {
            EXODataSet result;
            APIResponse parserResponse = parser.TryParse(path, out EXOParsedData data);

            if (!parserResponse.Success)
            {
                return new APIResponse<EXODataSet>(parserResponse, null);
            }

            planets = data.Planets.ToList();

            stars = data.Stars.ToList();

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
