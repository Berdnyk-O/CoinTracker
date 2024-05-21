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

        private string _seachName = string.Empty;
        public string SearchName
        {
            get => _seachName;
            set
            {
                _seachName = value;
                FilterRates();
                OnPropertyChanged(nameof(SearchName));
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
            OnPropertyChanged(nameof(Rates));
        }

        private void FilterRates()
        {
            if (string.IsNullOrEmpty(_seachName))
            {
                FilteredRates = Rates;
            }
            else
            {
                FilteredRates = new ObservableCollection<Rate>(
                    Rates.Where(x => x.Symbol.Contains(
                        _seachName, StringComparison.InvariantCultureIgnoreCase)));
            }
        }
    }
}
