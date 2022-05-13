using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Component.Elements
{
    internal class HtmlText : Element
    {
        public HtmlText(string contents, ElementOptions options) : base(contents, options)
        {
        }

        protected override string Name => "HtmlText";

        public override string GetCode()
        {
            var style = "position: absolute; ";
            style += $"left: {Options.Left}px; ";
            style += $"top: {Options.Top}px; ";
            style += $"width: {Options.Width}px; ";
            style += $"height: {Options.Height}px;";

            return 
            $@"<div style='{style}'>
                {Contents}
            </div>";
        }
    }
}
