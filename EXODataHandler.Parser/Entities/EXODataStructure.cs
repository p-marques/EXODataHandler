using System;
using System.Collections.Generic;

namespace EXODataHandler.Parser.Entities
{
    public struct EXODataStructure
    {
        private readonly string[] headers;

        public IReadOnlyList<string> Headers => Array.AsReadOnly(headers);

        public int PlanetNameIndex => FindHeaderIndex(Constants.PlanetNameHeader);

        public int StarNameIndex => FindHeaderIndex(Constants.HostNameHeader);

        public EXODataStructure(string[] inHeaders)
        {
            headers = inHeaders;
        }

        public static EXODataStructure Parse(string headersLine)
        {
            List<string> headers = new List<string>();
            
            string[] headersInFile = headersLine.Split(',');
            List<string> relevantHeaders = new List<string>(Constants.RelevantHeaders.Split(','));

            for (int i = 0; i < headersInFile.Length; i++)
            {
                string header = headersInFile[i].Trim();

                if (string.IsNullOrEmpty(header))
                    throw new Exception("Invalid column header.");

                if (relevantHeaders.Contains(header))
                {
                    if (headers.Contains(header))
                        throw new Exception("Repeated columns.");

                    headers.Add(header);
                }
            }

            if (!headers.Contains(Constants.HostNameHeader) ||
                !headers.Contains(Constants.PlanetNameHeader))
                throw new Exception("Mandatory column missing.");

            return new EXODataStructure(headers.ToArray());
        }

        private int FindHeaderIndex(string headerToFind)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                if (headerToFind == headers[i])
                    return i;
            }

            return -1;
        }
    }
}
