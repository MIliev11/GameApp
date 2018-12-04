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

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        { }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        { }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        { }
    }
}
