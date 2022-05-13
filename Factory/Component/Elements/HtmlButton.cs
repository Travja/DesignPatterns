using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Component.Elements
{
    internal class HtmlButton : Element
    {
        public HtmlButton(string contents, ElementOptions options) : base(contents, options)
        {
        }

        protected override string Name => "HtmlButton";

        public override string GetCode()
        {
            var style = "position: absolute; ";
            style += $"left: {Options.Left}px; ";
            style += $"top: {Options.Top}px; ";
            style += $"width: {Options.Width}px; ";
            style += $"height: {Options.Height}px;";

            return
            $@"<button style='{style}'>
                {Contents}
            </button>";
        }
    }
}
