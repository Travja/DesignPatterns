using Factory.Component.Elements;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Component
{
    public class UwpElementFactory : BaseFactory
    {
        private Stack<Element> _elements = new Stack<Element>();
        private const string format =
            @"<Page
                x:Class=""Factory.MainPage""
                xmlns = ""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                xmlns:x = ""http://schemas.microsoft.com/winfx/2006/xaml""
                xmlns:local = ""using:Factory""
                xmlns:d = ""http://schemas.microsoft.com/expression/blend/2008""
                xmlns:mc = ""http://schemas.openxmlformats.org/markup-compatibility/2006""
                mc:Ignorable = ""d""
                Background = ""{ThemeResource ApplicationPageBackgroundThemeBrush}"">
                <Grid>
                    ${elements}
                </Grid>
            </Page>";

        public Element CreateButton(string contents, ElementOptions options)
        {
            return new UwpButton(contents, options);
        }

        public Element CreateText(string contents, ElementOptions options)
        {
            return new UwpText(contents, options);
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
            var ret = format.Replace("${elements}", string.Join("\n", elements.Select(e => e.Build())));

            return ret;
        }
    }
}
