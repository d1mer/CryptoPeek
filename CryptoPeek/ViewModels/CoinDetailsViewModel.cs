using CryptoPeek.Extensions;
using CryptoPeek.Models.Coin;
using CryptoPeek.Models.Ohlc;
using CryptoPeek.Models.Tickers;
using CryptoPeek.Services.Crypto;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

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
            OpenUrlCommand = new DelegateCommand<string>(OpenUrl);
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

        public List<OhlcViewModel> Points { get; set; }

        private ObservableCollection<ISeries> _series;
        public ObservableCollection<ISeries> Series
        {
            get => _series;
            set => SetProperty(ref _series, value);
        }

        private ObservableCollection<Axis> _xAxis;
        public ObservableCollection<Axis> XAxis 
        {
            get => _xAxis;
            set => SetProperty(ref _xAxis, value); 
        }

        private ObservableCollection<Axis> _yAxis;
        public ObservableCollection<Axis> YAxis 
        {
            get => _yAxis;
            set => SetProperty(ref _yAxis, value);
        }

        private ObservableCollection<TickerViewModel> _tickers;
        public ObservableCollection<TickerViewModel> Tickers
        {
            get => _tickers;
            set => SetProperty(ref _tickers, value);
        }

        public ICommand BackCommand { get; }

        public ICommand OpenUrlCommand { get; }

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
                var coin = await _cryptoService.GetCoinByIdAsync(id);

                if (coin != null)
                {
                    Coin = coin.ToCoinFullViewModel();
                    CurrentPricesValue = Coin.MarketData.CurrentPrice.Values.First();
                }

                GetOhlcById(id);
                LoadTickers();
            }
        }

        private async Task GetOhlcById(string id)
        {
            var result = await _cryptoService.GetOhlcByCoinIdAsync(id);

            if (result != null && result.Count > 0)
            {
                Points = new List<OhlcViewModel>(result.Select(o => o.ToOhlcViewModel()));
                SetChartsData();
            }
        }

        private void SetChartsData()
        {
            var financialPoints = Points.Select(p => new FinancialPoint(
                p.Time,
                p.HighPrice,
                p.OpenPrice,
                p.ClosePrice,
                p.LowPrice
                )).ToList();

            Series = new ObservableCollection<ISeries>
            {
                new CandlesticksSeries<FinancialPoint>() 
                {
                    Values =  financialPoints,
                    UpStroke = new SolidColorPaint(SKColors.Green) {StrokeThickness = 2},
                    UpFill = new SolidColorPaint(SKColors.LightGreen),
                    DownStroke = new SolidColorPaint(SKColors.Red) {StrokeThickness = 2},
                    DownFill = new SolidColorPaint(SKColors.Pink),
                }
            };

            var labels = Points.Select(p => p.Time.ToString("dd.MM")).ToList();

            XAxis = new ObservableCollection<Axis>
            {
                new Axis
                {
                    Labeler = value => 
                    {
                        var ticks = (long)value;
                        
                        if (ticks < DateTime.MinValue.Ticks || ticks > DateTime.MaxValue.Ticks)
                        {
                            return string.Empty;
                        }

                        return new DateTime(ticks).ToString("dd.MM");
                    },
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    UnitWidth = TimeSpan.FromHours(2).Ticks,
                    MinStep   = TimeSpan.FromHours(2).Ticks
                }
            };

            YAxis = new ObservableCollection<Axis>
            {
                new Axis
                {
                    Labeler = val => "$" + val.ToString("N2")
                }
            };
        }

        private async Task LoadTickers()
        {
            var result = await _cryptoService.GetTickersAsync();

            if (result != null && result.Count > 0) 
            {
                var tickersViewModels = result.Select(t => t.ToTickerViewModel()).ToList();

                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    Tickers = new ObservableCollection<TickerViewModel>(tickersViewModels);
                });
            }
        }

        private void OpenUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(url)
                    {
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Open trade url error: {ex.Message}");
                }
            }
        }

        #endregion
    }
}
