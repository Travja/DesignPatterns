using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Component.Elements
{
    internal class UwpButton : Element
    {
        public UwpButton(string contents, ElementOptions options) : base(contents, options)
        {
        }

        public override string Build()
        {
            var style = "HorizontalAlignment=\"Left\" VerticalAlignment=\"Top\"";
            style += $"Margin=\"{Options.Left},{Options.Top},0,0\"";
            style += $"Width=\"{Options.Width}\"";
            style += $"Height=\"{Options.Height}\"";

            return
            $@"<Button {style}>
                {Contents}
            </Button>";
        }
    }
}
