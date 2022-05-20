using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    public class YellowState : IState
    {
        private TrafficLight _light;

        public YellowState(TrafficLight light)
        {
            _light = light;
        }

        public void SetGreen()
        {
            return;
        }

        public void SetRed()
        {
            _light.State = _light.RedState;
        }

        public void SetYellow()
        {
            return;
        }
    }
}
