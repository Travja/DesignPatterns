using Factory.Component.Elements;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Component
{
    public class UwpElementFactory : BaseFactory
    {
        public UwpElementFactory() : base(
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
            </Page>")
        { }

        public override Element CreateButton(string contents, ElementOptions options)
        {
            return new UwpButton(contents, options);
        }

        public override Element CreateText(string contents, ElementOptions options)
        {
            return new UwpText(contents, options);
        }
    }
}
