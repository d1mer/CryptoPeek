using CryptoPeek.Enums;
using System.Windows;

namespace CryptoPeek.Services.Theme
{
    public class ThemeService : IThemeService
    {
        private readonly Uri _lightThemeUri = new Uri("pack://application:,,,/Resources/Colors/LightColors.xaml", UriKind.Absolute);
        private readonly Uri _darkThemeUri = new Uri("pack://application:,,,/Resources/Colors/DarkColors.xaml", UriKind.Absolute);
        private EThemeType _currentTheme = EThemeType.Light;

        #region -- IThemeService implementation --

        public EThemeType CurrentTheme => _currentTheme;

        public event EventHandler<EThemeType> ThemeChanged;

        public void SetTheme(EThemeType theme)
        {
            if (theme == _currentTheme)
            {
                return;
            }

            _currentTheme = theme;
            var themeUri = theme == EThemeType.Light ? _lightThemeUri : _darkThemeUri;

            var newTheme = new ResourceDictionary
            {
                Source = themeUri,
            };

            var oldTheme = Application.Current.Resources.MergedDictionaries[0];
            Application.Current.Resources.MergedDictionaries.Remove(oldTheme);
            Application.Current.Resources.MergedDictionaries.Insert(0, newTheme);

            ThemeChanged?.Invoke(this, theme);
        }

        #endregion
    }
}
