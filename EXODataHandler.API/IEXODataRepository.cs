using EXODataHandler.API.Entities;
using EXODataHandler.Core;
using System;
using System.Collections.Generic;

namespace EXODataHandler.API
{
    public interface IEXODataRepository
    {
        APIResponse<EXODataSet> ParseFile(string path);

        APIResponse<List<Planet>> GetPlanets(Func<Planet, bool> predicate, 
            List<Planet> set = null);

        APIResponse<List<Star>> GetStars(Func<Star, bool> predicate,
            List<Star> set = null);
    }
}
