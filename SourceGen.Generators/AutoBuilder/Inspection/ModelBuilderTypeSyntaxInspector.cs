using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGen.Generators.AutoBuilder.Inspection;

internal class ModelBuilderTypeSyntaxInspector
{
    private readonly ModelBuilderPropertySyntaxInspector _propertySyntaxInspector;

    public ModelBuilderTypeSyntaxInspector(ModelBuilderPropertySyntaxInspector propertySyntaxInspector)
    {
        _propertySyntaxInspector = propertySyntaxInspector;
    }

    public ModelBuilderInfo Inspect(TypeDeclarationSyntax syntax)
    {
        string modelNamespaceName = GetModelNamespaceName(syntax);
        string modelTypeName = syntax.Identifier.ToString();
        string builderTypeName = $"{modelTypeName}Builder";
        ModelBuilderPropertyInfo[] builderProperties = GetPropertySyntaxes(syntax);
        
        return new ModelBuilderInfo(builderTypeName, modelTypeName, modelNamespaceName,
                                    builderProperties);
    }

    private string GetModelNamespaceName(TypeDeclarationSyntax syntax)
    {
        SyntaxNode? parentSyntax = syntax.Parent;
        if (parentSyntax == null)
        {
            throw new InvalidOperationException("Type declaration syntax has no parent syntax node.");
        }

        if (!(parentSyntax is BaseNamespaceDeclarationSyntax namespaceSyntax))
        {
            throw new InvalidOperationException("Type declaration syntax has non-namespace parent syntax. "
                                              + "The associated type definition may be a nested class.");
        }
        return namespaceSyntax.Name.ToString();
    }

    private ModelBuilderPropertyInfo[] GetPropertySyntaxes(TypeDeclarationSyntax syntax)
    {
        return syntax.Members
                     .OfType<PropertyDeclarationSyntax>()
                     .Select(s => _propertySyntaxInspector.Inspect(s))
                     .ToArray();
    }
}
