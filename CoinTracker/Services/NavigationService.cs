using CoinTracker.ViewModels;

namespace CoinTracker.Services
{
    public class NavigationService : ViewModelBase, INavigationService
    {
        private Func<Type, ViewModelBase> _viewModelFactory;
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentView 
        {
            get => _currentViewModel;
            private set 
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            var viewmodel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewmodel;
        }
    }
}
