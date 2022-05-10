using System;
using System.Collections;
using System.Collections.Generic;

namespace Trivia.Models.Iterator
{
    internal class NullIterator : IEnumerator<Component>
    {
        public Component Current => null;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}