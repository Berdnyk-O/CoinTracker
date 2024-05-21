using CoinTracker.Models;
using CoinTracker.Services;
using System.Collections.ObjectModel;

namespace CoinTracker.ViewModels
{
    public class ExchangesViewModel : ViewModelBase
    {
        private readonly ICoinCapService _coinCapService;

        public ObservableCollection<Exchange> Exchanges { get; set; } = null!;
        private ObservableCollection<Exchange> _filteredExchanges = null!;
        public ObservableCollection<Exchange> FilteredExchanges
        {
            get => _filteredExchanges;
            set
            {
                _filteredExchanges = value;
                OnPropertyChanged(nameof(FilteredExchanges));
            }
        }

        private string _seachName = string.Empty;
        public string SearchName
        {
            get => _seachName;
            set
            {
                _seachName = value;
                FilterExchanges();
                OnPropertyChanged(nameof(SearchName));
            }
        }

        public ExchangesViewModel(ICoinCapService coinCapService)
        {
            _coinCapService = coinCapService;
            _ = LoadAssets();
        }

        private async Task LoadAssets()
        {
            Exchanges = await _coinCapService.GetExchanges();
            FilteredExchanges = Exchanges;
        }

        private void FilterExchanges()
        {
            if (string.IsNullOrEmpty(_seachName))
            {
                FilteredExchanges = Exchanges;
            }
            else
            {
                FilteredExchanges = new ObservableCollection<Exchange>(
                    Exchanges.Where(x => x.Name.Contains(
                        _seachName, StringComparison.InvariantCultureIgnoreCase)));
            }
        }
    }
}
