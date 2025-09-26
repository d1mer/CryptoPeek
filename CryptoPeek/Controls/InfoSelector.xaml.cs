using System.Windows;
using System.Windows.Controls;

namespace CryptoPeek.Controls
{
    /// <summary>
    /// Interaction logic for InfoSelector.xaml
    /// </summary>
    public partial class InfoSelector : UserControl
    {
        public InfoSelector()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                nameof(Title),
                typeof(string),
                typeof(InfoSelector),
                new PropertyMetadata(string.Empty)
                );

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(
                nameof(Items),
                typeof(IEnumerable<string>),
                typeof(InfoSelector),
                new PropertyMetadata(null)
                );

        public IEnumerable<string> Items
        {
            get => (IEnumerable<string>)GetValue(ItemsProperty); 
            set => SetValue(ItemsProperty, value);
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(string),
                typeof(InfoSelector),
                new PropertyMetadata(string.Empty)
                );

        public string SelectedItem
        {
            get => (string)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register(
                nameof(SelectedValue),
                typeof(decimal),
                typeof(InfoSelector),
                new PropertyMetadata(default(decimal))
                );

        public decimal SelectedValue
        {
            get => (decimal)GetValue(SelectedValueProperty);
            set => SetValue(SelectedValueProperty, value);
        }
    }
}
