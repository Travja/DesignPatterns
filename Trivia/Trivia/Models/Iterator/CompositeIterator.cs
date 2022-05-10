using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Trivia.Models.Composite;

namespace Trivia.Models.Iterator
{
    public class CompositeIterator : IEnumerator<Component>
    {
        private readonly string _title;

        public string Title
        {
            get
            {
                if (_stack.Count <= 0) return _title;

                IEnumerator iter = _stack.First();
                if (iter is CompositeIterator comp)
                    return comp.Title;

                string cat = (string) _titles[iter];

                return cat ?? _title;
            }
        }

        private Hashtable _titles = new Hashtable();
        private Stack<IEnumerator<Component>> _stack = new Stack<IEnumerator<Component>>();

        public CompositeIterator(string title, IEnumerator<Component> iterator)
        {
            _title = title;
            _stack.Push(iterator);
        }

        object IEnumerator.Current => Current;

        public Component Current => _stack.Count > 0 ? _stack.First().Current : null;

        public bool MoveNext()
        {
            if (_stack.Count <= 0) return false;

            var iterator = _stack.Peek();
            if (!iterator.MoveNext())
            {
                _stack.Pop();
                return MoveNext();
            }

            var comp = iterator.Current;
            if (comp == null)
            {
                return MoveNext();
            }


            var iter = comp.GetEnumerator();
            if (!(iter is NullIterator))
            {
                iter.MoveNext();
                _stack.Push(iter);
            }

            if (comp is Category category)
                _titles.Add(iter, category.Title);

            return true;
        }

        public void Dispose()
        {
            _stack.Pop();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}