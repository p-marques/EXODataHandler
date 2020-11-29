using EXODataHandler.Core;
using EXODataHandler.Parser.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EXODataHandler.Parser.Entities
{
    public class EXODataSet
    {
        public LinkedList<Planet> Planets { get; }

        public LinkedList<Star> Stars { get; }

        public EXODataStructure DataStructure { get; }

        public EXODataSet(EXODataStructure structure)
        {
            Planets = new LinkedList<Planet>();

            Stars = new LinkedList<Star>();

            DataStructure = structure;
        }

        internal void AddPlanet(string line)
        {
            string[] values = line.Split(',');
            int planetIndex = DataStructure.FindHeaderIndex(Constants.PlanetNameHeader);
            int starIndex = DataStructure.FindHeaderIndex(Constants.HostNameHeader);
            string planetName = values[planetIndex].Trim();
            string starName = values[starIndex].Trim();

            if (Planets.GetAstroByName(planetName) != null)
                throw new Exception("Repeated planet.");

            Star thisPlanetStar = Stars.GetAstroByName(starName);

            if (thisPlanetStar == null)
            {
                thisPlanetStar = new Star(starName);

                Stars.AddLast(thisPlanetStar);
            }

            Planet newPlanet = new Planet(thisPlanetStar, planetName);

            thisPlanetStar.AddPlanet(newPlanet);

            Planets.AddLast(newPlanet);

            HandleDataFields(newPlanet, values);
        }

        private void HandleDataFields(Planet planet, string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                for (int k = 0; k < DataStructure.Headers.Count; k++)
                {
                    if (DataStructure.Headers[k].PositionIndex == i)
                    {
                        if(!string.IsNullOrWhiteSpace(values[i]))
                            AddDataField(planet, DataStructure.Headers[k].Id, values[i]);
                    }
                }
            }
        }

        //funcao para ver se field pertence a estrela ou planeta
        private void AddDataField(Planet planet, string id, string value)
        {
            if (id.StartsWith("s"))
            {
                planet.Host.AddDataField(GetDataField(id, value));
            }
            else
                planet.AddDataField(GetDataField(id, value));

        }

        private IDataField GetDataField(string id, string value)
        {
            ValueTypeEnum valueType = FindValueType(id);

            if (valueType == ValueTypeEnum.ValueTypeString)
            {
                return new DataField<string>(id, value);
            }
            else if (valueType == ValueTypeEnum.ValueTypeInt)
            {
                if (short.TryParse(value, out short shortValue))
                    return new DataField<short>(id, shortValue);
                else
                    throw new Exception("Year Data Field should be short.");
            }
            else if (float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out float floatValue))
            {
                return new DataField<float>(id, floatValue);
            }
            else if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleValue))
            {
                return new DataField<double>(id, doubleValue);
            }

            throw new Exception("Data Field unknown type.");
        }

        private ValueTypeEnum FindValueType(string id)
        {
            ValueTypeEnum finalType = ValueTypeEnum.ValueTypeFloat;
            
            switch (id)
            {
                case "pl_name":
                case "hostname":
                case "discoverymethod":
                    finalType = ValueTypeEnum.ValueTypeString;
                    break;
                case "disc_year":
                    finalType = ValueTypeEnum.ValueTypeInt;
                    break;
            }

            return finalType;
        }


    }
}
