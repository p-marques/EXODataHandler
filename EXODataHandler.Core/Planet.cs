using System.Collections.Generic;

namespace EXODataHandler.Core
{
    public class Planet : AstronomicalBody
    {
        public Star Host { get; }

        public Planet(Star host, string name) : base(name)
        {
            Host = host; 
        }
    }
}
