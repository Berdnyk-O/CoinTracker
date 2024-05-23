using CoinTracker.Models;
using CoinTracker.Services;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Xml;
using CoinTracker.Commands;

namespace CoinTracker.ViewModels
{
    public class AssetsViewModel : ViewModelBase
    {
        private readonly ICoinCapService _coinCapService;

        public ObservableCollection<Asset> Assets { get; set; } = null!;
        private ObservableCollection<Asset> _filteredAssets =  null!;
        public ObservableCollection<Asset> FilteredAssets
        {
            get => _filteredAssets;
            set
            {
                _filteredAssets = value;
                OnPropertyChanged(nameof(FilteredAssets));
            }
        }

        private string _seachName = string.Empty;
        public string SearchName
        { 
            get => _seachName;
            set 
            {
                _seachName = value;
                FilterAssets();
                OnPropertyChanged(nameof(SearchName));    
            } 
        }

        public ICommand NavigateToAssetsCommand { get; }

        public AssetsViewModel(ICoinCapService coinCapService)
        {
            _coinCapService = coinCapService;

            NavigateToAssetsCommand = new RelayCommand(NavigateToAssets);
            _ = LoadAssets();
        }

        private async Task LoadAssets()
        {
            Assets = await _coinCapService.GetAssets();
            FilteredAssets = Assets;
        }

        private void FilterAssets()
        {
            if(string.IsNullOrEmpty(_seachName))
            {
                FilteredAssets = Assets;
            }
            else
            {
                FilteredAssets = new ObservableCollection<Asset>(
                    Assets.Where(x => x.Name.Contains(
                        _seachName, StringComparison.InvariantCultureIgnoreCase)));
            }
        }

        private void NavigateToAssets(object id)
        {
            
        }
    }
}
