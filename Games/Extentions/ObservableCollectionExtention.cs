using System;
using System.Collections.ObjectModel;
using Games.ViewModel.GamePageViewModels.ComponentsViewModels;
using Games.Model.ButtonsGame;

namespace Games.Extentions
{
    public static class ObservableCollectionExtention
    {

        public static ObservableCollection<ButtonsHolderContentViewViewModel> RandomizeListOrder(this ObservableCollection<ButtonsHolderContentViewViewModel> collection)
        {
            Random random = new Random();

            for (int n = random.Next(6, 11); n > 1; n--)
            {
                for (int i = 0, j = i + n; j < collection.Count; j++, i++)
                {
                    ButtonsHolderContentViewViewModel temp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = temp;
                }
            }

            return collection;
        }

        public static EButtonType CollectedButtons(this ObservableCollection<ButtonsHolderContentViewViewModel> collection)
        {
            foreach (ButtonsHolderContentViewViewModel o in collection)
            {
                if (o.IsSelected)
                    return o.CurrentType;
            }
            return EButtonType.Null;
        }

        public static void UnselectAll(this ObservableCollection<ButtonsHolderContentViewViewModel> collection)
        {
            foreach (ButtonsHolderContentViewViewModel o in collection)
                o.IsSelected = false;
        }

    }
}
