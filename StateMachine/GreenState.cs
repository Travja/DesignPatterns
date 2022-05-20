using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    public class GreenState : IState
    {
        private TrafficLight _light;

        public GreenState(TrafficLight light)
        {
            _light = light;
        }

        public void SetGreen()
        {
            return;
        }

        public void SetRed()
        {
            return;
        }

        public void SetYellow()
        {
            _light.State = _light.YellowState;
        }
    }
}
