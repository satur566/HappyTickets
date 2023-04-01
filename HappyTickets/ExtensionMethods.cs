namespace HappyTickets
{
    using System.Collections.Generic;

    internal static class ExtensionMethods
    {
        internal static bool HasElementAtIndexOf<T>(this List<T> list, int index)
        {
            if (index < 0)
            {
                return false;
            }

            if (list.Count > index)
            {
                return true;
            }

            return false;
        }

        internal static bool HasElementAtIndexesOf(this List<List<long>> twoDimentionalList, int firstIndex, int secondIndex) =>
            twoDimentionalList.HasElementAtIndexOf(firstIndex)
            && twoDimentionalList[firstIndex].HasElementAtIndexOf(secondIndex);
    }
}
