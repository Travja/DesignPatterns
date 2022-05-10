using Factory.Component.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Component
{
    internal class UwpElementFactory : BaseFactory
    {
        public IElement CreateButton()
        {
            return new UwpButton();
        }

        public IElement CreateText()
        {
            return new UwpText();
        }

        public string ConstructPage(List<IElement> elements)
        {
            var format =
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

            return format;
        }
    }
}
