using System.Collections.Generic;
using System;

namespace EXODataHandler.Core
{
    public abstract class AstronomicalBody
    {
        public virtual string Name { get; }

        public AstronomicalBody(string name)
        {

            Name = name;

        }

    }
}
