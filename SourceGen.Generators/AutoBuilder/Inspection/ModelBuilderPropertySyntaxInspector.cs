using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace SourceGen.Generators.AutoBuilder.Inspection;

internal class ModelBuilderPropertySyntaxInspector
{
    public ModelBuilderPropertyInfo Inspect(PropertyDeclarationSyntax syntax)
    {
        string propertyName = syntax.Identifier.ToString();
        string propertyTypeName = syntax.Type.ToString();
        string memberName = GetPrivateMemberName(propertyName);
        return new ModelBuilderPropertyInfo(memberName, propertyTypeName, propertyName);
    }

    private string GetPrivateMemberName(string identifier)
    {
        char[] chars = identifier.ToCharArray();
        StringBuilder sb = new StringBuilder(chars.Length + 1);

        sb.Append('_');
        sb.Append(char.ToLower(chars[0]));

        for (int i = 1; i < chars.Length; i++)
        {
            sb.Append(chars[i]);
        }
        return sb.ToString();
    }
}