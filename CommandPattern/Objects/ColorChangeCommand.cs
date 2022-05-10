using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CommandPattern.Objects
{
    public class ColorChangeCommand : Command
    {

        private Rectangle Receiver { get; }
        private Brush Color { get; }
        private Brush Previous { get; set; }

        public ColorChangeCommand(Rectangle receiver, Brush color)
        {
            Receiver = receiver;
            Color = color;
        }

        public void Execute()
        {
            Previous = Receiver.Fill;
            Receiver.Fill = Color;
        }

        public void Undo()
        {
            if (Previous != null)
            {
                Receiver.Fill = Previous;
            }
        }
    }
}
