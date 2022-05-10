using System.Collections;
using System.Collections.Generic;

namespace Trivia.Models.Iterator
{
    public class ComponentIterator : IEnumerator<Component>
    {
        private Component[] Items { get; set; }
        private int _index = -1;

        public ComponentIterator(Component[] items)
        {
            Items = items;
        }

        public ComponentIterator(List<Component> items)
        {
            Items = items.ToArray();
        }

        public Component Current
        {
            get { return Items.Length > _index && _index >= 0 ? Items[_index] : null; }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            bool ret = false;
            if (Items.Length > _index + 1)
            {
                _index++;
                ret = true;
            }

            return ret;
        }

        public void Dispose()
        {
            Component[] tmp = new Component[Items.Length - 1];
            int n = 0;
            for (int i = 0; i < Items.Length; i++)
            {
                tmp[n++] = Items[i];
            }
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}