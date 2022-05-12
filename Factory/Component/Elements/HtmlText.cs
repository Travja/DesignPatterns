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

        public override string Build()
        {
            var style = "position: absolute; ";
            style += $"left: {Options.Left}; ";
            style += $"top: {Options.Top}; ";
            style += $"width: {Options.Width}; ";
            style += $"height: {Options.Height};";

            return 
            $@"<div style='{style}'>
                {Contents}
            </div>";
        }
    }
}
