using CoinTracker.ViewModels;

namespace CoinTracker.Services
{
    public interface INavigationService
    {
        ViewModelBase CurrentView { get; set; }
        void NavigateTo<TViewModel>(string? id=null) where TViewModel : ViewModelBase;
    }
}
