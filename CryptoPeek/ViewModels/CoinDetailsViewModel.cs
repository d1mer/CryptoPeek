using System.Windows.Input;
using CryptoPeek.Services.Crypto;

namespace CryptoPeek.ViewModels
{
    public class CoinDetailsViewModel : BindableBase
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

        public ICommand BackCommand { get; }

        #endregion

        #region -- Private helpers --

        private void OnBack()
        {
            var navigationService = _regionManager.Regions["MainRegion"].NavigationService;

            if (navigationService.Journal.CanGoBack)
                navigationService.Journal.GoBack();
        }

        #endregion
    }
}
