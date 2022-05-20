using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StateMachine
{
    public sealed partial class MainPage : Page
    {
        private TrafficLight _trafficLight;

        public MainPage()
        {
            this.InitializeComponent();
            _trafficLight = new TrafficLight(RedCircle, YellowCircle, GreenCircle);
        }

        public void SetGreen(object sender, RoutedEventArgs e) => _trafficLight.SetGreen();
        public void SetYellow(object sender, RoutedEventArgs e) => _trafficLight.SetYellow();
        public void SetRed(object sender, RoutedEventArgs e) => _trafficLight.SetRed();

        private void PageLoaded(object sender, RoutedEventArgs e) => _trafficLight.StartTimer();
    }
}
