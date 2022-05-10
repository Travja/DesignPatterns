using System;
using System.Collections.Generic;

namespace Trivia.Models.Composite
{
    public abstract class Category : Component
    {
        public string Title { get; }
        public string Description { get; }

        public Category(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public override string GetQuestion()
        {
            throw new NotImplementedException("This function has not been implemented");
        }

        public override string[] GetAnswers()
        {
            throw new NotImplementedException("This function has not been implemented");
        }

        public override int GetCorrectAnswer()
        {
            throw new NotImplementedException("This function has not been implemented");
        }

        public override void Shuffle()
        {
            throw new NotImplementedException("This function has not been implemented");
        }
    }
}
