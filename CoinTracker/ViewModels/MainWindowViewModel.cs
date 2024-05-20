using CoinTracker.Commands;
using CoinTracker.Services;

namespace CoinTracker.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private INavigationService _navigationService = null!;
        public INavigationService Navigation
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToAssetsCommand { get; set; }
        public RelayCommand NavigateToExchangesCommand { get; set; }
        public RelayCommand NavigateToRatesCommand { get; set; }
        public RelayCommand NavigateToMarketsCommand { get; set; }

        public MainWindowViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            
            NavigateToAssetsCommand = new RelayCommand(_ => Navigation.NavigateTo<AssetsViewModel>(), _ => true);
            NavigateToExchangesCommand = new RelayCommand(_=> Navigation.NavigateTo<ExchangesViewModel>(), _ => true);
            NavigateToRatesCommand = new RelayCommand(prop => { Navigation.NavigateTo<RatesViewModel>(); }, prop => true);
            NavigateToMarketsCommand = new RelayCommand(prop => { Navigation.NavigateTo<MarketsViewModel>(); }, prop => true);

            Navigation.NavigateTo<AssetsViewModel>();
        }
    }
}
