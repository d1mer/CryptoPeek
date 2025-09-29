using CryptoPeek.Enums;
using CryptoPeek.Services.Theme;
using System.Windows.Input;

namespace CryptoPeek.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IThemeService _themeService;

        public SettingsViewModel(IRegionManager regionManager, IThemeService themeService)
        {
            _regionManager = regionManager;
            _themeService = themeService;

            BackCommand = new DelegateCommand(OnBack);
            ToggleThemeCommand = new DelegateCommand(OnToggleTheme);
        }

        #region -- Public properties --

        private bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set => SetProperty(ref _isDarkTheme, value);
        }

        public ICommand BackCommand { get; }

        public ICommand ToggleThemeCommand { get; }

        #endregion

        #region -- Private helpers --

        private void OnBack()
        {
            var navigationService = _regionManager.Regions["MainRegion"].NavigationService;

            if (navigationService.Journal.CanGoBack)
                navigationService.Journal.GoBack();
        }

        private void OnToggleTheme()
        {
            var newTheme = _themeService.CurrentTheme == EThemeType.Light ? EThemeType.Dark : EThemeType.Light;
            _themeService.SetTheme(newTheme);
            IsDarkTheme = newTheme == EThemeType.Dark;
        }

        #endregion
    }
}
