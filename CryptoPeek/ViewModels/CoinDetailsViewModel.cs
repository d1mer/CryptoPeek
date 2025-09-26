using System.Windows.Input;
using CryptoPeek.Extensions;
using CryptoPeek.Models.Coin;
using CryptoPeek.Services.Crypto;

namespace CryptoPeek.ViewModels
{
    public class CoinDetailsViewModel : BindableBase, INavigationAware
    {
        private readonly ICryptoService _cryptoService;
        private readonly IRegionManager _regionManager;

        public CoinDetailsViewModel(ICryptoService cryptoService, IRegionManager regionManager)
        {
            _cryptoService = cryptoService;
            _regionManager = regionManager;

            BackCommand = new DelegateCommand(OnBack);
        }

        #region -- Public properties --

        private CoinFullViewModel _coin;
        public CoinFullViewModel Coin
        {
            get => _coin;
            set => SetProperty(ref _coin, value);
        }

        private decimal _currentPricesValue;
        public decimal CurrentPricesValue
        {
            get => _currentPricesValue;
            set => SetProperty(ref _currentPricesValue, value);
        }

        private string _selectedCurrentPrice;
        public string SelectedCurrentPrice
        {
            get => _selectedCurrentPrice;
            set
            {
                SetProperty(ref _selectedCurrentPrice, value);
                CurrentPricesValue = Coin.MarketData.CurrentPrice[_selectedCurrentPrice];
            }
        }

        private decimal _currentMarketCapValue;
        public decimal CurrentMarketCapValue
        {
            get => _currentMarketCapValue;
            set => SetProperty(ref _currentMarketCapValue, value);
        }

        private string _selectedMarketCap;
        public string SelectedMarketCap
        {
            get => _selectedMarketCap;
            set
            {
                SetProperty(ref _selectedMarketCap, value);
                CurrentMarketCapValue = Coin.MarketData.MarketCap[_selectedMarketCap];
            }
        }

        public ICommand BackCommand { get; }

        #endregion

        #region -- INavigationAware implementation --

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters != null)
            {
                var id = (string?)navigationContext.Parameters["id"];
                GetCoinById(id);
            }
        }

        #endregion

        #region -- Private helpers --

        private void OnBack()
        {
            var navigationService = _regionManager.Regions["MainRegion"].NavigationService;

            if (navigationService.Journal.CanGoBack)
                navigationService.Journal.GoBack();
        }

        private async Task GetCoinById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var coin = await _cryptoService.GetCoinById(id);
                Coin = coin.ToCoinFullViewModel();
                CurrentPricesValue = Coin.MarketData.CurrentPrice.Values.First();
            }
        }

        #endregion
    }
}
