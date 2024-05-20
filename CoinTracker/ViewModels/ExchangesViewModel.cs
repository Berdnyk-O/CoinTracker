using CoinTracker.Models;
using CoinTracker.Services;
using System.Collections.ObjectModel;

namespace CoinTracker.ViewModels
{
    public class ExchangesViewModel : ViewModelBase
    {
        public ObservableCollection<Exchange> Exchanges { get; set; } = null!;

        private readonly ICoinCapService _coinCapService;

        public ExchangesViewModel(ICoinCapService coinCapService)
        {
            _coinCapService = coinCapService;
            _ = LoadAssets();
        }

        private async Task LoadAssets()
        {
            Exchanges = await _coinCapService.GetExchanges();
            OnPropertyChanged(nameof(Exchanges));
        }
    }
}
