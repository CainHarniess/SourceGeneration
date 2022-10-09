using System.Text;

namespace SourceGen.Generators.AutoBuilder.Writers;

internal class WithMethodWriter : AbstractSourceWriter
{
    public WithMethodWriter(StringBuilder sb) : base(sb)
    {

    }

    public void Append(ModelBuilderPropertyInfo propertyInfo, string builderTypeName)
    {
        Sb.AppendLine($@"    public {builderTypeName} With{propertyInfo.PropertyName}({propertyInfo.MemberTypeName} value)
    {{
        {propertyInfo.MemberName} = value;
        return this;
    }}
");
    }
}