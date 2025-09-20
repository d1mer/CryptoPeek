using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using CryptoPeek.Services.Rest;


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
        protected override Window CreateShell()
        {
            var window = Container.Resolve<MainWindow>();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IRestService,  RestService>();
        }
    }

}
