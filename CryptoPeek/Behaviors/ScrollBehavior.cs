using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;

namespace CryptoPeek.Behaviors
{
    public static class ScrollBehavior
    {
        #region -- Public properties --

        public static readonly DependencyProperty FixMouseWheelScrollProperty =
            DependencyProperty.RegisterAttached(
                "FixMouseWheelScroll",
                typeof(bool),
                typeof(ScrollBehavior), 
                new PropertyMetadata(false, onFixMouseWheelScrollChanged)
                );

        #endregion

        #region -- Public methods --

        public static bool GetFixMouseWheelScroll(DependencyObject obj ) => (bool)obj.GetValue(FixMouseWheelScrollProperty);

        public static void SetFixMouseWheelScroll(DependencyObject obj, bool value)
        {
            obj.SetValue(FixMouseWheelScrollProperty, value);
        }

        #endregion

        #region -- Private helpers --

        private static void onFixMouseWheelScrollChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if ((bool)e.NewValue)
                {
                    element.PreviewMouseWheel += OnPreviewMouseWheel;
                }
                else
                {
                    element.PreviewMouseWheel -= OnPreviewMouseWheel;
                }
            }
        }

        private static void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = FindParentScrollViewer(sender as DependencyObject);

            if (scrollViewer != null)
            {
                e.Handled = true;

                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                {
                    RoutedEvent = UIElement.MouseWheelEvent,
                    Source = sender,
                };

                scrollViewer.RaiseEvent(eventArg);
            }
        }

        private static ScrollViewer FindParentScrollViewer(DependencyObject? dependencyObject)
        {
            if (dependencyObject == null)
                return null;

            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null)
                return null;

            if (parent is ScrollViewer scrollViewer)
                return scrollViewer;

            return FindParentScrollViewer(parent);
        }

        #endregion
    }
}
