using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CommandPattern.Objects
{
    public class MoveCommand : Command
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        private Rectangle Rectangle { get; set; }

        public MoveCommand(Rectangle rectangle, int dx, int dy)
        {
            Rectangle = rectangle;
            X = dx;
            Y = dy;
        }

        public void Execute()
        {
            Rectangle.RenderTransform = new TranslateTransform()
            {
                X = ((TranslateTransform)Rectangle.RenderTransform).X + X,
                Y = ((TranslateTransform)Rectangle.RenderTransform).Y + Y
            };
        }

        public void Undo()
        {
            Rectangle.RenderTransform = new TranslateTransform()
            {
                X = ((TranslateTransform)Rectangle.RenderTransform).X - X,
                Y = ((TranslateTransform)Rectangle.RenderTransform).Y - Y
            };
        }
    }
}
