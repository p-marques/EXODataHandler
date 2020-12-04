using System;
using System.Collections.Generic;
using EXODataHandler.Parser.Helpers;

namespace EXODataHandler.Parser.Entities
{
    public struct EXODataStructure
    {
        private readonly EXODataHeader[] headers;

        public IReadOnlyList<EXODataHeader> Headers => Array.AsReadOnly(headers);

        public EXODataStructure(EXODataHeader[] inHeaders)
        {
            headers = inHeaders;
        }

        public static EXODataStructure Parse(string headersLine)
        {
            List<EXODataHeader> headers = new List<EXODataHeader>();

            string[] headersInFile = headersLine.Split(',');

            List<string> relevantHeaders = new List<string>(Constants.RelevantHeaders.Split(','));

            for (short i = 0; i < headersInFile.Length; i++)
            {
                EXODataHeader header = new EXODataHeader(headersInFile[i].Trim(), i);

                if (string.IsNullOrEmpty(header.Id))
                    throw new Exception("Invalid column header.");

                Console.WriteLine($"Relevant: {relevantHeaders[i]} Header ID: {header.Id}");
                if (relevantHeaders.Contains(header.Id))
                {
                    if (headers.Contains(header))
                        throw new Exception("Repeated columns.");

                    headers.Add(header);
                }
            }

            if (!headers.ContainsHeaderName(Constants.PlanetNameHeader) ||
                !headers.ContainsHeaderName(Constants.HostNameHeader))
                throw new Exception("Mandatory column missing.");

            return new EXODataStructure(headers.ToArray());
        }
        public int FindHeaderIndex(string headerToFind)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                if (headerToFind == headers[i].Id)
                    return i;
            }

            return -1;
        }
    }
}
