using System.Collections.ObjectModel;
using CryptoPeek.Extensions;
using CryptoPeek.Models.Coin;
using CryptoPeek.Services.Crypto;


namespace CryptoPeek.ViewModels
{
    public class CoinsViewModel : BindableBase, INavigationAware
    {
        private readonly ICryptoService _cryptoService;

        public CoinsViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        #region -- Public properties --

        private ObservableCollection<CoinShortViewModel> _coins;
        public ObservableCollection<CoinShortViewModel> Coins 
        {
            get => _coins;
            set => SetProperty(ref _coins, value);
        }

        #endregion

        #region -- INavigationAware implementation --

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            UpdateCoins();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
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
            var coins = await _cryptoService.GetCoinsList();

            if (coins != null && coins.Count > 0)
            {
                Coins = new ObservableCollection<CoinShortViewModel>(coins.Select(c => c.ToCoinShortViewModel()));
            }
        }

        #endregion
    }
}
