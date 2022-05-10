using System.Collections.Generic;
using Trivia.Models.Iterator;

namespace Trivia.Models.Composite
{
    public class BasicCategory : Category
    {
        private Component[] Items { get; set; } = new Component[0];

        public BasicCategory(string title, string description) : base(title, description)
        {
        }

        public override void Add(Component comp)
        {
            Component[] tmp = new Component[Items.Length + 1];
            for (int i = 0; i < Items.Length; i++)
            {
                tmp[i] = Items[i];
            }

            tmp[tmp.Length - 1] = comp;
            Items = tmp;
        }

        public override void Remove(Component comp)
        {
            int index = -1;
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i].Equals(comp))
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                Component[] tmp = new Component[Items.Length - 1];
                int i = 0;
                int j = 0;
                while (i < Items.Length)
                {
                    if (i != index)
                        tmp[i] = Items[j++];
                    i++;
                }
            }
        }

        public override IEnumerator<Component> GetEnumerator() =>
            new CompositeIterator(Title, new ComponentIterator(Items));
    }
}