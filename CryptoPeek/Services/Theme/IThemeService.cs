using CryptoPeek.Enums;

namespace CryptoPeek.Services.Theme
{
    public interface IThemeService
    {
        EThemeType CurrentTheme { get; }

        void SetTheme(EThemeType theme);

        event EventHandler<EThemeType> ThemeChanged;
    }
}
