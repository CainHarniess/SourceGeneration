using Microsoft.CodeAnalysis;

namespace SourceGen.Generators;

public static class GeneratorExecutionContextQueryExtensions
{
    public static SyntaxTree[] GetAllSyntaxTrees(this GeneratorExecutionContext context)
    {
        return context.Compilation
                      .SyntaxTrees
                      .ToArray();
    }
}