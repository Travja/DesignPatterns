using Factory.Component.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Component
{
    public interface BaseFactory
    {

        Element CreateButton(string contents, ElementOptions options);

        Element CreateText(string contents, ElementOptions options);

        void AddElement(Element element);

        Element RemoveElement();

        string ConstructPage(List<Element> elements);

    }
}
