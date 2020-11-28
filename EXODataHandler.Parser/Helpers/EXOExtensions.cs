using EXODataHandler.Core;
using System.Collections.Generic;

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
    }
}
