using Factory.Component;
using Factory.Component.Elements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Factory
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private BaseFactory _factory;
        private readonly ObservableCollection<Element> _elements = new ObservableCollection<Element>();

        public MainPage()
        {
            _factory = new HtmlElementFactory();
            this.InitializeComponent();
        }

        private void ValidateNumber(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ElementSelection.SelectedItem == null) return;
            var elementType = (ElementSelection.SelectedItem as ComboBoxItem).Content as string;
            if (elementType == null || elementType.Trim().Length == 0) return;

            var options = new ElementOptions()
            {
                Top = int.Parse(ElementTop.Text),
                Left = int.Parse(ElementLeft.Text),
                Width = int.Parse(ElementWidth.Text),
                Height = int.Parse(ElementHeight.Text),
            };

            var content = ElementContent.Text;
            var btn = new RawElement(elementType, content, options);

            _elements.Add(btn);
        }

        private async void ClickExport(object sender, RoutedEventArgs e)
        {
            if (ExportFormat.SelectedItem == null) return;
            var exportType = (ExportFormat.SelectedItem as ComboBoxItem).Content as string;
            if (exportType == null || exportType.Trim().Length == 0) return;

            BaseFactory factory = exportType.Equals("HTML")
                ? new HtmlElementFactory()
                : new UwpElementFactory();

            var text = factory.ConstructPage(_elements
                .Select(e => e is RawElement raw ? raw.Build(factory) : e)
                .ToList());

            Preview.Text = text;

            var dialog = new FileSavePicker();
            dialog.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            dialog.FileTypeChoices.Add(exportType, new List<string>() { exportType.Equals("HTML") ? ".html" : ".xaml" });
            dialog.SuggestedFileName = "Page";

            Windows.Storage.StorageFile file = await dialog.PickSaveFileAsync();
            if (file == null) return;

            // Prevent updates to the remote version of the file until
            // we finish making changes and call CompleteUpdatesAsync.
            Windows.Storage.CachedFileManager.DeferUpdates(file);
            // write to file
            await Windows.Storage.FileIO.WriteTextAsync(file, text);
            // Let Windows know that we're finished changing the file so
            // the other app can update the remote version of the file.
            // Completing updates may require Windows to ask for user input.
            Windows.Storage.Provider.FileUpdateStatus status =
                await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);

            if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                ShowDialog("File saved!");
            else
                ShowDialog("File could not be saved...");
        }

        public async void ShowDialog(string content)
        {
            var messageDialog = new MessageDialog(content);

            messageDialog.Commands.Add(new UICommand("OK"));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;

            await messageDialog.ShowAsync();
        }
    }
}
