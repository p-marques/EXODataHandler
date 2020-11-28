using System.Collections.Generic;

namespace EXODataHandler.Core
{
    public abstract class AstronomicalBody
    {
        protected ICollection<IDataField> dataFields;

        public virtual string Name { get; }

        public AstronomicalBody(string name)
        {
            Name = name;

            dataFields = new LinkedList<IDataField>();
        }
    }
}
