using System.Windows;
using System.Windows.Controls;

namespace CryptoPeek.Controls
{
    public class ExpandableTextBlock : Control
    {
        static ExpandableTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExpandableTextBlock), new FrameworkPropertyMetadata(typeof(ExpandableTextBlock)));
        }

        #region -- Public properties --

        public static readonly DependencyProperty TextProperty = 
            DependencyProperty.Register(
                nameof(Text),
                typeof(string),
                typeof(ExpandableTextBlock),
                new PropertyMetadata(string.Empty)
                );

        public string Text
        {
            get => (string)GetValue(TextProperty); 
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty CollapsedLinesProperty =
            DependencyProperty.Register(
                nameof(CollapsedLines), 
                typeof(int), 
                typeof(ExpandableTextBlock), 
                new PropertyMetadata(3));

        public int CollapsedLines
        {
            get => (int)GetValue(CollapsedLinesProperty);
            set => SetValue(CollapsedLinesProperty, value);
        }

        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(
                nameof(IsExpanded), 
                typeof(bool), 
                typeof(ExpandableTextBlock),
                new PropertyMetadata(false));

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        #endregion
    }
}
