using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace Games.ViewModel
{
    public class ViewModelBase : BindableBase, INavigationAware
    {

        protected INavigationService NavigationService { get; private set; }

        public ViewModelBase(INavigationService navigation)
        {
            NavigationService = navigation;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {

        }
    }
}
