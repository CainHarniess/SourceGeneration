using System.Text;

namespace SourceGen.Generators.AutoBuilder.Writers
{
    internal abstract class AbstractSourceWriter
    {
        private readonly StringBuilder _sb;

        protected AbstractSourceWriter(StringBuilder sb)
        {
            _sb = sb;
        }

        protected StringBuilder Sb => _sb;
    }
}
