using System.Collections.Generic;
using Trivia.Models.Iterator;

namespace Trivia.Models.Composite
{
    class AdvancedCategory : Category
    {
        private List<Component> Items { get; set; } = new List<Component>();

        public AdvancedCategory(string title, string description) : base(title, description)
        {
        }

        public override void Add(Component comp) => Items.Add(comp);

        public override void Remove(Component comp) => Items.Remove(comp);

        public override IEnumerator<Component> GetEnumerator() => new CompositeIterator(Title, Items.GetEnumerator());
    }
}