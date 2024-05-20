using CoinTracker.Models;
using System.Collections.ObjectModel;

namespace CoinTracker.Services
{
    public interface ICoinCapService
    {
        public Task<ObservableCollection<Asset>> GetAssets();
        public Task<ObservableCollection<Rate>> GetRates();
        public Task<ObservableCollection<Exchange>> GetExchanges();
        public Task<ObservableCollection<Market>> GetMarkets();
    }
}
