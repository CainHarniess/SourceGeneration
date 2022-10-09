using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGen.Generators;

public static class TreeDeclarationSyntaxAttributeExtensions
{
    internal static bool IsBuildable(this TypeDeclarationSyntax syntax)
    {
        return syntax.AttributeLists
                     .Any(a => a.ToString()
                                .StartsWith("[Buildable"));
    }
}


