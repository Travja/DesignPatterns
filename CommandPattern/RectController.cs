using CommandPattern.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CommandPattern
{
    public class RectController
    {

        private readonly Rectangle receiver;
        private readonly Stack<Command> invokedCommands = new Stack<Command>();
        private const int step = 50;

        public RectController(Rectangle receiver)
        {
            this.receiver = receiver;
        }

        public void Invoke(Command command)
        {
            if (command == null) return;
            invokedCommands.Push(command);
            command.Execute();
        }

        public void Undo()
        {
            int lastIndex = invokedCommands.Count - 1;
            if (lastIndex < 0) return;

            Command cmd = invokedCommands.Pop();
            cmd.Undo();
        }

        public void PressKey(VirtualKey key)
        {
            Command cmd = null;

            switch (key)
            {
                case VirtualKey.W:
                case VirtualKey.Up:
                    cmd = new MoveCommand(receiver, 0, -step);
                    break;
                case VirtualKey.D:
                case VirtualKey.Right:
                    cmd = new MoveCommand(receiver, step, 0);
                    break;
                case VirtualKey.S:
                case VirtualKey.Down:
                    cmd = new MoveCommand(receiver, 0, step);
                    break;
                case VirtualKey.A:
                case VirtualKey.Left:
                    cmd = new MoveCommand(receiver, -step, 0);
                    break;
            }

            Invoke(cmd);
        }

        public void SetColor(Brush color)
        {
            Invoke(new ColorChangeCommand(receiver, color));
        }

    }
}
