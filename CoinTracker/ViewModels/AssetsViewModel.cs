using CoinTracker.Models;
using CoinTracker.Services;
using System.Collections.ObjectModel;

namespace CoinTracker.ViewModels
{
    public class AssetsViewModel : ViewModelBase
    {
        public ObservableCollection<Asset> Assets { get; set; } = null!;

        private readonly ICoinCapService _coinCapService;

        public AssetsViewModel(ICoinCapService coinCapService)
        {
            _coinCapService = coinCapService;
            _ = LoadAssets();
        }

        private async Task LoadAssets()
        {
            Assets = await _coinCapService.GetAssets();
            OnPropertyChanged(nameof(Assets));
        }
    }
}
