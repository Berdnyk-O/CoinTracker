using CoinTracker.Models;
using CoinTracker.Services;
using System.Collections.ObjectModel;

namespace CoinTracker.ViewModels
{
    public class RatesViewModel : ViewModelBase
    {
        public ObservableCollection<Rate> Rates { get; set; } = null!;

        private readonly ICoinCapService _coinCapService;

        public RatesViewModel(ICoinCapService coinCapService)
        {
            _coinCapService = coinCapService;
            _ = LoadAssets();
        }

        private async Task LoadAssets()
        {
            Rates = await _coinCapService.GetRates();
            OnPropertyChanged(nameof(Rates));
        }
    }
}
