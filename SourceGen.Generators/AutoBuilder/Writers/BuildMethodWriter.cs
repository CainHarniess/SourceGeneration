using System.Text;

namespace SourceGen.Generators.AutoBuilder.Writers;

internal class BuildMethodWriter : AbstractSourceWriter
{
    public BuildMethodWriter(StringBuilder sb) : base(sb)
    {

    }

    public void Append(ModelBuilderPropertyInfo[] properties, string modelTypeName)
    {
        Sb.AppendLine($@"    public override {modelTypeName} Build()
    {{
        return new {modelTypeName}
        {{");
        for (int i = 0; i < properties.Length; i++)
        {
            ModelBuilderPropertyInfo property = properties[i];
            Sb.AppendLine($@"            {property.PropertyName} = {property.MemberName},");
        }
        Sb.AppendLine($@"        }};");
        Sb.AppendLine($@"    }}");
    }
}
