using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CryptoPeek.Controls
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
            UpdatePlaceholderVisibility();
        }

        #region -- Public properties --

        public static readonly DependencyProperty IsFocusedSearchBoxProperty =
            DependencyProperty.Register(
                nameof(IsFocusedSearchBox),
                typeof(bool),
                typeof(SearchBox)
                );

        public new bool IsFocusedSearchBox
        {
            get => (bool)GetValue(IsFocusedSearchBoxProperty);
            set => SetValue(IsFocusedSearchBoxProperty, value);
        }

        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register(
                nameof(SearchText),
                typeof(string),
                typeof(SearchBox),
                new PropertyMetadata(string.Empty)
                );

        public string SearchText
        {
            get => (string)GetValue(SearchTextProperty);
            set => SetValue (SearchTextProperty, value);
        }

        #endregion

        #region -- Private helpers --

        private void UpdatePlaceholderVisibility()
        {
            PlaceholderText.Visibility = string.IsNullOrEmpty(SearchTextBox.Text) 
                ? Visibility.Visible 
                : Visibility.Collapsed;
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            IsFocusedSearchBox = true;
            PlaceholderText.Visibility = Visibility.Collapsed;
            MainBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            MainBorder.BorderThickness = new Thickness(2);
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            IsFocusedSearchBox = false;
            SearchTextBox.Text = string.Empty;
            MainBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(224, 224, 224));
            MainBorder.BorderThickness = new Thickness(1);

            UpdatePlaceholderVisibility();
        }

        #endregion
    }
}
