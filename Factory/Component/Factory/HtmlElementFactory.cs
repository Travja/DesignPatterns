using Factory.Component.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Component
{
    internal class HtmlElementFactory : BaseFactory
    {
        public IElement CreateButton()
        {
            return new HtmlButton();
        }

        public IElement CreateText()
        {
            return new HtmlText();
        }

        public string ConstructPage(List<IElement> elements)
        {
            var format = @"<!DOCTYPE html>
            <html>
                <head>
                </head>
                <body>
                ${elements}
                </body>
            </html>
            ";

            return format;
        }
    }
}
