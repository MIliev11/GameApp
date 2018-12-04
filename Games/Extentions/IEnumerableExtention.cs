using System;
using Games.ControllsViewModels;
using System.Collections.Generic;
using Games.Model;
using System.Linq;

namespace Games.Extentions
{
    public static class IListExtention
    {

        public static void RandomizeOrder(this IList<SelectedButtonViewModel> collection)
        {
            Random rnd = new Random();

            foreach (SelectedButtonViewModel first in collection)
            {
                foreach (SelectedButtonViewModel second in collection)
                {
                    if (rnd.NextDouble() > 0.5)
                    {
                        EButtonType type = second.CurrentType;
                        second.CurrentType = first.CurrentType;
                        first.CurrentType = type;
                    }
                }
            }
        }

        public static bool IsAnotherSelected(this IList<SelectedButtonViewModel> collection, EButtonType type, int sortedPosition)
        {
            for (int i = sortedPosition; i < collection.Count; i++)
                if (collection[i].IsSelected && !collection[i].CurrentType.Equals(type))
                    return true;

            return false;
        }

        public static void ReselectIfOrdered(this IList<SelectedButtonViewModel> collection, EButtonType type, int sortedPosition)
        {
            for (int i = 0; i < sortedPosition; i++)
                collection[i].IsSelected = true;
        }

        public static void UnselectAll(this IList<SelectedButtonViewModel> collection, int sortedPosition)
        {
            for (int i = sortedPosition; i < collection.Count; i++)
                collection[i].IsSelected = false;
        }

        public static int GetSelectedByType(this IList<SelectedButtonViewModel> collection, EButtonType type, int sortedPosition)
        {
            int result = 0;

            for (int i = sortedPosition; i < collection.Count; i++)
                if (collection[i].IsSelected && collection[i].CurrentType.Equals(type))
                    result++;

            return result;
        }

        public static void ReorderByType(this IList<SelectedButtonViewModel> collection, EButtonType type, int sortedPosition)
        {
            for (int i = sortedPosition; i < sortedPosition + 4; i++)
            {
                if (collection[i].CurrentType.Equals(type))
                    continue;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CurrentType.Equals(type))
                    {
                        EButtonType temp = collection[i].CurrentType;
                        collection[i].CurrentType = collection[j].CurrentType;
                        collection[j].CurrentType = temp;

                        collection[i].IsSelected = true;
                        collection[j].IsSelected = false;

                        break;
                    }
                }
            }
        }

    }
}
