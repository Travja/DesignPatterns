using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Component.Elements
{
    public abstract class Element
    {
        protected abstract string Name { get; }
        protected string Contents { get; set; }
        protected ElementOptions Options { get; set; }
        public Element(string contents, ElementOptions options)
        {
            Contents = contents;
            Options = options;
        }

        public abstract string GetCode();

        public override string ToString()
        {
            return Name;
        }
    }
}
