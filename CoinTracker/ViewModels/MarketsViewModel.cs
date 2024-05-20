using CoinTracker.Models;
using CoinTracker.Services;
using System.Collections.ObjectModel;

namespace CoinTracker.ViewModels
{
    public class MarketsViewModel : ViewModelBase
    {
        public ObservableCollection<Market> Markets { get; set; } = null!;

        private readonly ICoinCapService _coinCapService;

        public MarketsViewModel(ICoinCapService coinCapService)
        {
            _coinCapService = coinCapService;
            _ = LoadAssets();
        }

        private async Task LoadAssets()
        {
            Markets = await _coinCapService.GetMarkets();
            OnPropertyChanged(nameof(Markets));
        }
    }
}
