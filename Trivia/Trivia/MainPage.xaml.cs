using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Trivia.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Trivia.Models.Composite;
using Trivia.Models.Iterator;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Trivia
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly TriviaController _controller = new TriviaController();
        private CompositeIterator _controllerIterator = null;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Grid_Loading(FrameworkElement sender, object args)
        {
            _controllerIterator = (CompositeIterator) _controller.GetEnumerator();
            _controllerIterator.MoveNext();
            SetQuestion(_controllerIterator.Current);
        }

        private void SetQuestion(Component component)
        {
            if (component is Question)
            {
                component.Shuffle();
                QuestText.Text = component.GetQuestion();

                int i = 0;
                Ans1.Content = component.GetAnswers()[i++];
                Ans2.Content = component.GetAnswers()[i++];
                Ans3.Content = component.GetAnswers()[i++];
                Ans4.Content = component.GetAnswers()[i++];
                StatusText.Text = "";
            }

            CategoryText.Text = _controllerIterator.Title;
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!_controllerIterator.MoveNext())
            {
                SetQuestion(new Question("That's the end.", new[] { "", "", "", "" }));
                return;
            }

            SetQuestion(_controllerIterator.Current);
        }

        public void AnsClick(object sender, RoutedEventArgs e)
        {
            if (_controllerIterator.Current == null) return;

            Control control = sender as Control;
            if (!control.Name.StartsWith("Ans")) return;
            int index = int.Parse(control.Name.Replace("Ans", "")) - 1;

            int correct = _controllerIterator.Current.GetCorrectAnswer();

            if (index == correct)
            {
                StatusText.Text = "Correct!";
            }
            else
            {
                StatusText.Text = "Incorrect ;(";
            }
        }
    }
}