using CoinTracker.Models;
using CoinTracker.Services;
using System.Collections.ObjectModel;

namespace CoinTracker.ViewModels
{
    class AssetMarketsDataViewModel : ViewModelBase
    {
        private readonly ICoinCapService _coinCapService;

        private ObservableCollection<AssetMarketData> _assetMarkets = null!;
        public ObservableCollection<AssetMarketData> AssetMarkets
        {
            get => _assetMarkets;
            set
            {
                _assetMarkets = value;
                OnPropertyChanged(nameof(AssetMarkets));
            }
        }

        public AssetMarketsDataViewModel(ICoinCapService coinCapService, string id)
        {
            _coinCapService = coinCapService;
            _ = LoadAssetMarkets(id);
        }

        private async Task LoadAssetMarkets(string id)
        {
            AssetMarkets = await _coinCapService.GetMarketDataForAsset(id);
            
        }


    }
}
