using System;
using System.Collections.Generic;

namespace Trivia.Models
{
    public abstract class Component
    {
        public abstract void Add(Component comp);

        public abstract void Remove(Component comp);

        public abstract IEnumerator<Component> GetEnumerator();

        public abstract string GetQuestion();

        public abstract string[] GetAnswers();

        public abstract int GetCorrectAnswer();

        public abstract void Shuffle();
    }
}