using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGen.Generators;

public static class SyntaxTreeAutoBuilderExtensions
{
    public static TypeDeclarationSyntax[] GetDescendantAutoBuilderTypeNodes(this SyntaxTree tree)
    {
        bool result = tree.TryGetRoot(out SyntaxNode? root);
        if (root == null)
        {
            throw new InvalidOperationException($"Syntax tree returned a null root.");
        }
        return root.DescendantNodes()
                   .OfType<TypeDeclarationSyntax>()
                   .Where(t => t.IsBuildable())
                   .ToArray();
    }
}


