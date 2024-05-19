using CoinTracker.Models;
using CoinTracker.Service;
using System.Collections.ObjectModel;

namespace CoinTracker.ViewModels
{
    public class AssetViewModel : ViewModelBase
    {
        public ObservableCollection<Asset> Assets { get; set; }

        private readonly ICoinCapService _coinCapService;

        public AssetViewModel(ICoinCapService coinCapService)
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
