using System.Text;

namespace SourceGen.Generators.AutoBuilder.Writers;

internal class ModelBuilderClassWriter : AbstractSourceWriter
{
    public ToolInfo ToolInfo { get; }
    public string ToolName { get; }
    private readonly MemberDeclarationWriter _memberWriter;
    private readonly WithMethodWriter _withMethodWriter;
    private readonly BuildMethodWriter _buildMethodWriter;

    public ModelBuilderClassWriter(StringBuilder sb, MemberDeclarationWriter memberDeclarationWriter,
        WithMethodWriter withMethodWriter, BuildMethodWriter buildMethodWriter, ToolInfo toolInfo) : base(sb)
    {
        _memberWriter = memberDeclarationWriter;
        _withMethodWriter = withMethodWriter;
        _buildMethodWriter = buildMethodWriter;
        ToolInfo = toolInfo;
    }

    public void Append(ModelBuilderInfo builderInfo)
    {
        Sb.AppendLine($"namespace {builderInfo.ModelNamespaceName};\r\n");
        Sb.AppendLine($@"[GeneratedCode(""{ToolInfo.Name}"", ""{ToolInfo.Version}"")]
public partial class {builderInfo.TypeName} : AbstractBuilder<{builderInfo.ModelTypeName}>
{{");
        AppendClassBody(builderInfo);
        Sb.AppendLine($@"}}");
    }

    private void AppendClassBody(ModelBuilderInfo builderInfo)
    {
        var props = builderInfo.Properties;
        for (int i = 0; i < props.Length; i++)
        {
            var prop = props[i];
            _memberWriter.Append(prop);
            _withMethodWriter.Append(prop, builderInfo.TypeName);
        }
        _buildMethodWriter.Append(props, builderInfo.ModelTypeName);
    }
}
