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

        APIResponse<List<Planet>> OrderPlanets<T>(List<Planet> set,
            OrderByType orderByType,
            Func<Planet, T> keySelector, 
            Func<Planet, T> secondaryKeySelector = null);

        APIResponse<List<Star>> OrderStars<T>(List<Star> set,
            OrderByType orderByType,
            Func<Star, T> keySelector, 
            Func<Star, T> secondaryKeySelector = null);
    }
}
