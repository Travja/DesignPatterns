using Windows.UI.Core;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Foundation;

namespace CommandPattern
{
    public sealed partial class MainPage : Page
    {

        private RectController controller;

        public MainPage()
        {
            InitializeComponent();

            Window.Current.CoreWindow.Activated += CoreWindow_Resize;
            Window.Current.CoreWindow.ResizeCompleted += CoreWindow_Resize;
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            controller = new RectController(rect);
        }

        public void CoreWindow_Resize(CoreWindow sender, object args)
        {
            RectangleGeometry geometry = new RectangleGeometry
            {
                Rect = new Rect(0, 0, grid.ColumnDefinitions[0].ActualWidth, grid.ActualHeight)
            };
            canv.Clip = geometry;
        }

        public void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            controller.PressKey(args.VirtualKey);
        }

        public void SetOrange(object sender, RoutedEventArgs e)
        {
            controller.SetColor(new SolidColorBrush(Colors.Orange));
        }

        public void SetGreen(object sender, RoutedEventArgs e)
        {
            controller.SetColor(new SolidColorBrush(Colors.LimeGreen));
        }

        public void SetBlue(object sender, RoutedEventArgs e)
        {
            controller.SetColor(new SolidColorBrush(Colors.Blue));
        }

        private void Undo(object sender, RoutedEventArgs e)
        {
            controller.Undo();
        }
    }
}