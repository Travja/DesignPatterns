using Factory.Component.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Component
{
    public class HtmlElementFactory : BaseFactory
    {
        private Stack<Element> _elements = new Stack<Element>();
        public HtmlElementFactory() : base(
            @"<!DOCTYPE html>
            <html>
                <head>
                </head>
                <body>
                ${elements}
                </body>
            </html>")
        { }

        public override Element CreateButton(string contents, ElementOptions options)
        {
            return new HtmlButton(contents, options);
        }

        public override Element CreateText(string contents, ElementOptions options)
        {
            return new HtmlText(contents, options);
        }
    }
}
