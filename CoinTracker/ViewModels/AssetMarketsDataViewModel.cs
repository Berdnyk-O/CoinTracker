using CoinTracker.Models;
using CoinTracker.Services;
using System.Collections.ObjectModel;

namespace CoinTracker.ViewModels
{
    class AssetMarketsDataViewModel : ViewModelBase
    {
        private readonly ICoinCapService _coinCapService;

        public ObservableCollection<AssetMarketData> AssetMarkets { get; set; } = null!;

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
