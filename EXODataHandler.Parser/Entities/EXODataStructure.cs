using EXODataHandler.Parser.Helpers;
using System;
using System.Collections.Generic;

namespace EXODataHandler.Parser.Entities
{
    /// <summary>
    /// Struct used to create the DataStructure 
    /// </summary>
    public struct EXODataStructure
    {
        /// <summary>
        /// Array of EXODataHeaders
        /// </summary>
        private readonly EXODataHeader[] headers;

        /// <summary>
        /// Property used to get Read only list with the file headers
        /// </summary>
        public IReadOnlyList<EXODataHeader> Headers => Array.AsReadOnly(headers);

        /// <summary>
        /// Constructor for the EXODataStructure class
        /// </summary>
        /// <param name="inHeaders">Array of Headers in file</param>
        public EXODataStructure(EXODataHeader[] inHeaders)
        {
            headers = inHeaders;
        }

        /// <summary>
        /// Creates the Data Structure with the desired Headers
        /// </summary>
        /// <param name="headersLine">Line with headers in file</param>
        /// <returns></returns>
        public static EXODataStructure Parse(string headersLine)
        {
            //Creates a new list of EXODataHeaders
            List<EXODataHeader> headers = new List<EXODataHeader>();

            //Creates an Array with all headers foun in line
            string[] headersInFile = headersLine.Split(',');

            //Creates a new List with all the Relevant Headers
            List<string> relevantHeaders =
                new List<string>(Constants.RelevantHeaders.Split(','));

            //Cycle that adds a valid header to the EXODataHeaders list
            for (short i = 0; i < headersInFile.Length; i++)
            {
                //Creates a new EXODataHeader based on the current 
                //header being read
                EXODataHeader header = new EXODataHeader(headersInFile[i].Trim(), i);

                //If the header doesn't have an ID...
                if (string.IsNullOrEmpty(header.Id))

                    //...throws an Invalid Header Exception
                    throw new Exception("Invalid column header.");


                //Checks if the relevantHeaders list has an header 
                //with the current header ID...
                if (relevantHeaders.Contains(header.Id))
                {
                    //...if it has it checks if the EXODataHeader List
                    //already has the current header...
                    if (headers.Contains(header))

                        //...and if so throws a Repeated Column Exception
                        throw new Exception("Repeated columns.");

                    //else it adds the current header to EXODataHeader List
                    headers.Add(header);
                }
            }

            //Checks if the EXODataHeaders list doesn't contain the headers
            //with the corresponding Constant...
            if (!headers.ContainsHeaderName(Constants.PlanetNameHeader) ||
                !headers.ContainsHeaderName(Constants.HostNameHeader))

                //...and throws an Mandatory Column Missing Exception
                throw new Exception("Mandatory column missing.");

            //return the new EXODataStructure with the EXODataHeaders list
            //into an array
            return new EXODataStructure(headers.ToArray());
        }

        /// <summary>
        /// Method used the return Header's Index
        /// </summary>
        /// <param name="headerToFind">Header ID to be found</param>
        /// <returns>Returns the corresponding Index of said header</returns>
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
