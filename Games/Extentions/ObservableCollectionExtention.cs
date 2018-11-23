using System;
using System.Collections.ObjectModel;
using Games.ViewModel.GamePageViewModels.ComponentsViewModels;
using Games.Model.ButtonsGame;
using System.Collections.Generic;

namespace Games.Extentions
{
    public static class ObservableCollectionExtention
    {

        private static int currentOrderPosition = 0;

        public static List<ButtonsHolderContentViewViewModel> RandomizeListOrder(this List<ButtonsHolderContentViewViewModel> collection)
        {
            Random random = new Random();

            for (int n = random.Next(6, 14); n > 1; n--)
            {
                for (int i = 0, j = i + n; j < collection.Count; j++, i++)
                {
                    EButtonType temp = collection[i].CurrentType;
                    collection[i].CurrentType = collection[j].CurrentType;
                    collection[j].CurrentType = temp;
                }
            }

            return collection;
        }

        public static bool IsAnotherSelected(this List<ButtonsHolderContentViewViewModel> collection, EButtonType type)
        {
            foreach (ButtonsHolderContentViewViewModel vm in collection)
                if (vm.IsSelected && !vm.IsOrdered)
                    if (vm.CurrentType != type)
                        return true;
            return false;
        }

        public static void UnselectAll(this List<ButtonsHolderContentViewViewModel> collection)
        {
            foreach (ButtonsHolderContentViewViewModel o in collection)
                o.IsSelected = false;
        }

        public static int GetNumberOfSelectedButton(this List<ButtonsHolderContentViewViewModel> collection)
        {
            int result = 0;

            foreach (ButtonsHolderContentViewViewModel vm in collection)
                if (vm.IsSelected && !vm.IsOrdered)
                    result++;

            return result;
        }

        public static void ReorderByType(this List<ButtonsHolderContentViewViewModel> collection, EButtonType type)
        {
            for (int i = currentOrderPosition; i < currentOrderPosition + 4; i++)
            {
                for (int j = i; j < collection.Count; j++)
                {
                    if (collection[j].CurrentType == type)
                    {
                        EButtonType temp = collection[i].CurrentType;
                        collection[i].CurrentType = collection[j].CurrentType;
                        collection[j].CurrentType = temp;
                        collection[j].IsSelected = false;
                        collection[i].IsOrdered = true;
                        break;
                    }
                }
            }

            currentOrderPosition += 4;
        }

        public static bool IsAllOrdered(this List<ButtonsHolderContentViewViewModel> collection)
        {
            return currentOrderPosition == 16;
        }

    }
}
