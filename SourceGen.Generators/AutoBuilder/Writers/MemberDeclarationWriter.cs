using System.Text;

namespace SourceGen.Generators.AutoBuilder.Writers
{
    internal class MemberDeclarationWriter : AbstractSourceWriter
    {
        public MemberDeclarationWriter(StringBuilder sb) : base(sb)
        {

        }

        public void Append(ModelBuilderPropertyInfo propertyInfo)
        {
            Sb.AppendLine($@"    private {propertyInfo.MemberTypeName} {propertyInfo.MemberName};");
        }
    }
}
