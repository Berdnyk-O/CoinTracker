using CoinTracker.ViewModels;

namespace CoinTracker.Services
{
    public interface INavigationService
    {
        ViewModelBase CurrentView { get; }
        void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
    }
}
