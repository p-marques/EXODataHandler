using EXODataHandler.Core;
using System.Collections.Generic;
using EXODataHandler.Parser.Entities;

namespace EXODataHandler.Parser.Helpers
{
    /// <summary>
    /// Class used to create exterior class methods
    /// </summary>
    internal static class EXOExtensions
    {
        /// <summary>
        /// Method used to get the Astonomical's body name
        /// </summary>
        /// <typeparam name="T">Type of Astronomical Body</typeparam>
        /// <param name="linkedList">LinkedList of Astronomical Body Type T</param>
        /// <param name="name">Name of the Astronomical Body</param>
        /// <returns></returns>
        internal static T GetAstroByName<T>(this LinkedList<T> linkedList, string name) where T : AstronomicalBody
        {
            LinkedListNode<T> node;

            //Cycle that goes through the list
            for (node = linkedList.First; node != null; node = node.Next)
            {
                //if it finds an equal name returns the Astro's name
                if (node.Value.Name == name)
                    return node.Value;
            }

            return null;
        }

        /// <summary>
        /// Method used to check if the EXODataHeader list contains a certain header
        /// </summary>
        /// <param name="headerList">List of Headers</param>
        /// <param name="name">Name of desired Header</param>
        /// <returns></returns>
        internal static bool ContainsHeaderName(this IList<EXODataHeader> headerList, string name)
        {
            for (int i = 0; i < headerList.Count; i++)
            {
                if (headerList[i].Id == name) return true;
            }

            return false;
        }
    
    }
}
