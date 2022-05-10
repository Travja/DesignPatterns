using Factory.Component.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Component
{
    public interface BaseFactory
    {

        IElement CreateButton();

        IElement CreateText();

        string ConstructPage(List<IElement> elements);

    }
}
