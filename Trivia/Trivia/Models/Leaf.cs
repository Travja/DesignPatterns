using System;
using System.Collections.Generic;
using Trivia.Models.Iterator;

namespace Trivia.Models
{
    public abstract class Leaf : Component
    {
        public override void Add(Component comp)
        {
            throw new NotImplementedException("This function has not been implemented");
        }

        public override void Remove(Component comp)
        {
            throw new NotImplementedException("This function has not been implemented");
        }

        public override IEnumerator<Component> GetEnumerator()
        {
            return new NullIterator();
        }
    }
}