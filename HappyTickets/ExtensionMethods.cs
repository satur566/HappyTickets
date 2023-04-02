namespace HappyTickets
{
    using System.Collections.Generic;

    internal static class ExtensionMethods
    {
        internal static bool HasElementAtIndexOf<T>(this List<T> list, int index) =>
            index >= 0 && list.Count > index;

        internal static bool HasElementAtIndexesOf(this List<List<long>> twoDimentionalList, int firstIndex, int secondIndex) =>
            twoDimentionalList.HasElementAtIndexOf(firstIndex)
            && twoDimentionalList[firstIndex].HasElementAtIndexOf(secondIndex);
    }
}
