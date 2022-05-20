using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    public interface IState
    {
        void SetGreen();
        void SetYellow();
        void SetRed();
    }
}
