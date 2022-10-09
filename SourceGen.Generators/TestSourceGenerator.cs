using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using SourceGen.Generators.AutoBuilder.Inspection;
using SourceGen.Generators.AutoBuilder.Writers;
using SourceGen.Generators.AutoBuilder;
using System.Diagnostics;
using System.Text;

namespace SourceGen.Generators;

internal class TestSourceGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        SyntaxTree[] syntaxTrees = context.GetAllSyntaxTrees();

        for (int i = 0; i < syntaxTrees.Length; i++)
        {
            TypeDeclarationSyntax[] buildables = syntaxTrees[i].GetDescendantAutoBuilderTypeNodes();

            if (buildables.Length == 0)
            {
                continue;
            }

            foreach (TypeDeclarationSyntax buildable in buildables)
            {
                GenerateBuilderClassFile(context, buildable);
            }
        }
    }

    public void Initialize(GeneratorInitializationContext context)
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            Debugger.Launch();
        }
#endif
    }

    private void GenerateBuilderClassFile(GeneratorExecutionContext context, TypeDeclarationSyntax buildable)
    {
        StringBuilder sb = new();
        BaseTypeInspector inspector = new();

        inspector.Inspect(buildable);
    }
}
