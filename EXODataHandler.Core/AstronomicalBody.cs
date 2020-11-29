using System.Collections.Generic;
using System;

namespace EXODataHandler.Core
{
    public abstract class AstronomicalBody
    {
        protected IList<IDataField> dataFields;

        public virtual string Name { get; }

        public IList<IDataField> DataFields => dataFields;

        public AstronomicalBody(string name)
        {
            Name = name;

            dataFields = new List<IDataField>();
        }

        public virtual void AddDataField(IDataField dataField)
        {
            dataFields.Add(dataField);
        }
    }
}
