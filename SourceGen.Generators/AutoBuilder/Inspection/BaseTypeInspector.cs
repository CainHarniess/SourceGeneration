using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGen.Generators.AutoBuilder.Inspection;

internal class BaseTypeInspector
{
    public void Inspect(TypeDeclarationSyntax syntax)
    {
        BaseListSyntax? baseListSyntax = syntax.BaseList;  
    }
}
