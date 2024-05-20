using CoinTracker.Commands;
using CoinTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.ViewModels
{
    public class ExchangesViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
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

        public ExchangesViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            NavigateToAssetsCommand = new RelayCommand(prop => { Navigation.NavigateTo<AssetsViewModel>(); }, prop => true);
            NavigateToExchangesCommand = new RelayCommand(prop => { Navigation.NavigateTo<ExchangesViewModel>(); }, prop => true);
            NavigateToRatesCommand = new RelayCommand(prop => { Navigation.NavigateTo<RatesViewModel>(); }, prop => true);
            NavigateToMarketsCommand = new RelayCommand(prop => { Navigation.NavigateTo<MarketsViewModel>(); }, prop => true);
        }
    }
}
