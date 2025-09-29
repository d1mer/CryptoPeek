using System.Collections.ObjectModel;
using System.Windows.Input;
using CryptoPeek.Enums;
using CryptoPeek.Extensions;
using CryptoPeek.Models.Coin;
using CryptoPeek.Services.Crypto;


namespace CryptoPeek.ViewModels
{
    public class CoinsViewModel : BindableBase, INavigationAware
    {
        private readonly ICryptoService _cryptoService;
        private readonly IRegionManager _regionManager;
        private List<CoinShortViewModel> _coinsCache;

        public CoinsViewModel(ICryptoService cryptoService, IRegionManager regionManager)
        {
            _cryptoService = cryptoService;
            _regionManager = regionManager;

            OpenCoinDetailsCommand = new DelegateCommand<CoinShortViewModel>(OnOpenCoinDetails);
            ClearSearchCommand = new DelegateCommand(OnClearSearch);
            SettingsCommand = new DelegateCommand(OnSettings);
        }

        #region -- Public properties --

        private ObservableCollection<CoinShortViewModel> _coins;
        public ObservableCollection<CoinShortViewModel> Coins 
        {
            get => _coins;
            set => SetProperty(ref _coins, value);
        }

        public bool IsSearchFocused
        {
            set
            {
                if (value)
                    OnSearchBoxFocused();
            }
        }

        private string _searchText = string.Empty;
        public string SearchText
        {
            get => _searchText;
            set
            {
                PerformSearch(value);
            }
        }

        public ICommand OpenCoinDetailsCommand { get; }

        public ICommand ClearSearchCommand { get; }

        public ICommand SettingsCommand { get; }

        #endregion

        #region -- INavigationAware implementation --

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            UpdateCoins();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #endregion

        #region -- Private helpers --

        private async Task UpdateCoins()
        {
            var coins = await _cryptoService.GetCoinsListAsync();

            if (coins != null && coins.Count > 0)
            {
                Coins = new ObservableCollection<CoinShortViewModel>(coins.Select(c => c.ToCoinShortViewModel()));
            }
        }

        private void OnSearchBoxFocused()
        {
            if (Coins != null && Coins.Count > 0)
            {
                CopyCoins(ECoinsCopyDirection.ToCache);
            }
        }

        private void PerformSearch(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var coinsItems = Coins.Where(i => i.Name.Contains(value, StringComparison.OrdinalIgnoreCase) || i.Symbol.Contains(value, StringComparison.OrdinalIgnoreCase)).ToList();
                var cachedItems = _coinsCache.Where(i => i.Name.Contains(value, StringComparison.OrdinalIgnoreCase) || i.Symbol.Contains(value, StringComparison.OrdinalIgnoreCase)).ToList();

                var combinedItems = coinsItems.Concat(cachedItems)
                                              .GroupBy(i => i.Name)
                                              .Select(g => g.First())
                                              .ToList();

                Coins = new ObservableCollection<CoinShortViewModel>(combinedItems);
            }
            else if (_coinsCache != null)
            {
                Coins = new ObservableCollection<CoinShortViewModel>(_coinsCache);
            }
        }

        private void CopyCoins(ECoinsCopyDirection direction)
        {
            switch (direction)
            {
                case ECoinsCopyDirection.ToCache:
                    _coinsCache = new List<CoinShortViewModel>(Coins);
                    break;
                case ECoinsCopyDirection.ToPermanent:
                    if (_coinsCache.Count != Coins.Count)
                    {
                        Coins = new ObservableCollection<CoinShortViewModel>(_coinsCache);
                    }
                    
                    _coinsCache.Clear();
                    _coinsCache = default;
                    break;
            }
        }

        private void OnOpenCoinDetails(CoinShortViewModel coin)
        {
            if (coin != null)
            {
                _cryptoService.StartLoadingTickersByCoinId(coin.Id);

                var navigationParameters = new NavigationParameters
                {
                    {
                        "id", coin.Id
                    }
                };

                _regionManager.RequestNavigate("MainRegion", "CoinDetailsView", navigationParameters);
            }
        }

        private void OnClearSearch()
        {
            if (_coinsCache != null && _coinsCache.Count > 0)
            {
                CopyCoins(ECoinsCopyDirection.ToPermanent);
            }
        }

        private void OnSettings()
        {
            _regionManager.RequestNavigate("MainRegion", "SettingsView");
        }

        #endregion
    }
}
