using CoinTracker.Models;
using CoinTracker.Services;
using System.Collections.ObjectModel;

namespace CoinTracker.ViewModels
{
    public class RatesViewModel : ViewModelBase
    {
        private readonly ICoinCapService _coinCapService;

        public ObservableCollection<Rate> Rates { get; set; } = null!;
        private ObservableCollection<Rate> _filteredRates = null!;
        public ObservableCollection<Rate> FilteredRates
        {
            get => _filteredRates;
            set
            {
                _filteredRates = value;
                OnPropertyChanged(nameof(FilteredRates));
            }
        }

        private string _seachSymbol = string.Empty;
        public string SeachSymbol
        {
            get => _seachSymbol;
            set
            {
                _seachSymbol = value;
                FilterRates();
                OnPropertyChanged(nameof(SeachSymbol));
            }
        }

        public RatesViewModel(ICoinCapService coinCapService)
        {
            _coinCapService = coinCapService;
            _ = LoadAssets();
        }

        private async Task LoadAssets()
        {
            Rates = await _coinCapService.GetRates();
            FilteredRates = Rates;
        }

        private void FilterRates()
        {
            if (string.IsNullOrEmpty(_seachSymbol))
            {
                FilteredRates = Rates;
            }
            else
            {
                FilteredRates = new ObservableCollection<Rate>(
                    Rates.Where(x => x.Symbol.Contains(
                        _seachSymbol, StringComparison.InvariantCultureIgnoreCase)));
            }
        }
    }
}
