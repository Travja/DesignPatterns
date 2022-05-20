using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    internal class RedState : IState
    {
        private TrafficLight _light;

        public RedState(TrafficLight light)
        {
            _light = light;
        }

        public void SetGreen()
        {
            _light.State = _light.GreenState;
        }

        public void SetRed()
        {
            return;
        }

        public void SetYellow()
        {
            return;
        }
    }
}
