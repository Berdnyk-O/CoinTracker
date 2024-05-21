using CoinTracker.Models;
using CoinTracker.Services;
using System.Collections.ObjectModel;

namespace CoinTracker.ViewModels
{
    public class MarketsViewModel : ViewModelBase
    {
        private readonly ICoinCapService _coinCapService;

        public ObservableCollection<Market> Markets { get; set; } = null!;
        private ObservableCollection<Market> _filteredMarkets = null!;
        public ObservableCollection<Market> FilteredMarkets
        {
            get => _filteredMarkets;
            set
            {
                _filteredMarkets = value;
                OnPropertyChanged(nameof(FilteredMarkets));
            }
        }

        private string _seachName = string.Empty;
        public string SearchName
        {
            get => _seachName;
            set
            {
                _seachName = value;
                FilterMarkets();
                OnPropertyChanged(nameof(SearchName));
            }
        }

        public MarketsViewModel(ICoinCapService coinCapService)
        {
            _coinCapService = coinCapService;
            _ = LoadAssets();
        }

        private async Task LoadAssets()
        {
            Markets = await _coinCapService.GetMarkets();
            FilteredMarkets = Markets;
            OnPropertyChanged(nameof(Markets));
        }

        private void FilterMarkets()
        {
            if (string.IsNullOrEmpty(_seachName))
            {
                FilteredMarkets = Markets;
            }
            else
            {
                FilteredMarkets = new ObservableCollection<Market>(
                    Markets.Where(x => x.BaseId.Contains(
                        _seachName, StringComparison.InvariantCultureIgnoreCase)));
            }
        }
    }
}
