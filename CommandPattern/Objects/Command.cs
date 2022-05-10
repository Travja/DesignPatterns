using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Objects
{
    public interface Command
    {
        void Execute();
        void Undo();
    }
}
