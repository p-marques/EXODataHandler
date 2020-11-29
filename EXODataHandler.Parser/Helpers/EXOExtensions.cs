using EXODataHandler.Core;
using System.Collections.Generic;
using EXODataHandler.Parser.Entities;

namespace EXODataHandler.Parser.Helpers
{
    internal static class EXOExtensions
    {
        internal static T GetAstroByName<T>(this LinkedList<T> linkedList, string name) where T : AstronomicalBody
        {
            LinkedListNode<T> node;

            for (node = linkedList.First; node != null; node = node.Next)
            {
                if (node.Value.Name == name)
                    return node.Value;
            }

            return null;
        }

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
