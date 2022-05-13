using Factory.Component.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Component
{
    public abstract class BaseFactory
    {
        protected string _format;

        protected BaseFactory(string format)
        {
            _format = format;
        }

        public Element CreateElement(string type, string contents, ElementOptions options)
        {
            switch (type)
            {
                case "Button":
                    return CreateButton(contents, options);
                case "Text":
                    return CreateText(contents, options);
                default:
                    throw new ArgumentException($"{type} is not a recognized element");
            }
        }

        public abstract Element CreateButton(string contents, ElementOptions options);

        public abstract Element CreateText(string contents, ElementOptions options);

        public string ConstructPage(List<Element> elements)
        {
            var ret = _format.Replace("${elements}", string.Join("\n", elements.Select(e => e.GetCode())));

            return ret;
        }

    }
}
