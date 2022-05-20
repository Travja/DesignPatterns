using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace StateMachine
{
    public class TrafficLight
    {
        private readonly Shape _red, _yellow, _green;
        private readonly Brush _redFill, _yellowFill, _greenFill;
        private IState _state;
        private bool _running = false;
        public IState State
        {
            get { return _state; }
            set
            {
                _state = value;
                _red.Fill = _redFill;
                _yellow.Fill = _yellowFill;
                _green.Fill = _greenFill;

                if (value is RedState)
                    _red.Fill = new SolidColorBrush(Colors.Red);
                else if (value is YellowState)
                    _yellow.Fill = new SolidColorBrush(Colors.Yellow);
                else if (value is GreenState)
                    _green.Fill = new SolidColorBrush(Colors.Green);
            }
        }

        public IState RedState, YellowState, GreenState;

        public TrafficLight(Shape red, Shape yellow, Shape green)
        {
            _red = red;
            _yellow = yellow;
            _green = green;

            _redFill = _red.Fill;
            _yellowFill = _yellow.Fill;
            _greenFill = _green.Fill;

            RedState = new RedState(this);
            YellowState = new YellowState(this);
            GreenState = new GreenState(this);

            State = RedState;
        }

        public void SetGreen() => State.SetGreen();
        public void SetYellow() => State.SetYellow();
        public void SetRed() => State.SetRed();

        public async Task StartTimer()
        {
            if (_running) return;

            _running = true;
            var window = Window.Current;
            await Task.Run(async () =>
            {
                while (true)
                {
                    Thread.Sleep(5000);
                    await window.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        if (State is RedState)
                            SetGreen();
                        else if (State is YellowState)
                            SetRed();
                        else if (State is GreenState)
                            SetYellow();
                    });
                }
            });
        }
    }
}
