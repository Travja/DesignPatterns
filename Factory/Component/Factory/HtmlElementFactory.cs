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
        private const string format = @"<!DOCTYPE html>
            <html>
                <head>
                </head>
                <body>
                ${elements}
                </body>
            </html>";

        public Element CreateButton(string contents, ElementOptions options)
        {
            return new HtmlButton(contents, options);
        }

        public Element CreateText(string contents, ElementOptions options)
        {
            return new HtmlText(contents, options);
        }

        public string ConstructPage()
        {
            var ret = format.Replace("${elements}", string.Join("\n", _elements.Select(e => e.Build())));

            return ret;
        }

        public void AddElement(Element element)
        {
            _elements.Push(element);
        }

        public Element RemoveElement()
        {
            return _elements.Pop();
        }

        public string ConstructPage(List<Element> elements)
        {
            throw new NotImplementedException();
        }
    }
}
