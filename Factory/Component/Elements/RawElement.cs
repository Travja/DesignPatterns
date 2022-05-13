using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Component.Elements
{
    public class RawElement : Element
    {
        private string _name;
        protected override string Name => _name;
        public RawElement(string name, string content, ElementOptions options) : base(content, options)
        {
            _name = name;
        }

        public Element Build(BaseFactory factory)
        {
            return factory.CreateElement(Name, Contents, Options);
        }

        public override string GetCode()
        {
            throw new NotSupportedException("Raw elements don't support GetCode");
        }

        public override string ToString()
        {
            return $"{_name}: top={Options.Top} left={Options.Left} width={Options.Width} height={Options.Height}";
        }
    }
}
