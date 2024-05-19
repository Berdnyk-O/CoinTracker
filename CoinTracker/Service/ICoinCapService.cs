using CoinTracker.Models;
using System.Collections.ObjectModel;

namespace CoinTracker.Service
{
    public interface ICoinCapService
    {
        public Task<ObservableCollection<Asset>> GetAssets();
    }
}
