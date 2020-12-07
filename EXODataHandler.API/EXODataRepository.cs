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

            result = new EXODataSet(new List<Planet>(planets),
                new List<Star>(stars));

            return new APIResponse<EXODataSet>(parserResponse, result);
        }

        public APIResponse<List<Planet>> GetPlanets(Func<Planet, bool> predicate)
        {
            try
            {
                List<Planet> result = planets.Where(predicate).ToList();

                return new APIResponse<List<Planet>>(true, result);
            }
            catch (Exception e)
            {
                return new APIResponse<List<Planet>>(false, null, e.Message);
            }
        }
    }
}
