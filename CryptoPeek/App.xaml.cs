using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using CryptoPeek.Services.Crypto;
using CryptoPeek.Services.Rest;
using CryptoPeek.Views;


namespace CryptoPeek
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public static IConfiguration Configuration { get; private set; }

        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<App>();

            Configuration = builder.Build();
        }

        protected override void OnInitialized()
        {
            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.RequestNavigate("MainRegion", nameof(CoinsView));

            base.OnInitialized();
        }

        protected override Window CreateShell()
        {
            var window = Container.Resolve<MainWindow>();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IRestService,  RestService>();
            containerRegistry.RegisterSingleton<ICryptoService, CryptoService>();

            containerRegistry.RegisterForNavigation<CoinsView>();
            containerRegistry.RegisterForNavigation<CoinDetailsView>();
        }
    }

}
