using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Models.Iterator;

namespace Trivia.Models
{
    public class Question : Leaf
    {
        private static readonly Random Rng = new Random();
        private string Title { get; set; }
        private string[] Answers { get; set; }
        private int CorrectAnswer { get; set; } = 0;

        public Question(string title, string[] answers)
        {
            Title = title;
            Answers = answers;
        }

        public override string GetQuestion()
        {
            return Title;
        }

        public override string[] GetAnswers()
        {
            return Answers;
        }

        public override int GetCorrectAnswer()
        {
            return CorrectAnswer;
        }

        public override void Shuffle()
        {
            string ans = Answers[CorrectAnswer];
            List<string> source = Answers.ToList();
            string[] tmp = new string[Answers.Length];

            int n = 0;
            while (source.Count > 0)
            {
                int k = Rng.Next(source.Count);

                string value = source[k];

                tmp[n] = value;
                source.RemoveAt(k);
                if (value.Equals(ans))
                    CorrectAnswer = n;
                n++;
            }

            Answers = tmp;
        }
    }
}