using CoinTracker.ViewModels;

namespace CoinTracker.Services
{
    public class NavigationService : ViewModelBase, INavigationService
    {
        private Func<Type,string?, ViewModelBase> _viewModelFactory = null!;

        private ViewModelBase _currentViewModel = null!;
        public ViewModelBase CurrentView 
        {
            get => _currentViewModel;
            set 
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, string?, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>(string? id = null) where TViewModel : ViewModelBase
        {
            var viewmodel = _viewModelFactory.Invoke(typeof(TViewModel), id);
            CurrentView = viewmodel;
        }
    }
}
