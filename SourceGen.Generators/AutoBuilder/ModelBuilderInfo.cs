namespace SourceGen.Generators.AutoBuilder;

public class ModelBuilderInfo
{
    public ModelBuilderInfo(string builderTypeName, string modelTypeName,
                            string modelNamespaceName, ModelBuilderPropertyInfo[] properties)
    {
        TypeName = builderTypeName;
        ModelTypeName = modelTypeName;
        ModelNamespaceName = modelNamespaceName;
        Properties = properties;
    }

    public string TypeName { get; }
    public string ModelTypeName { get; }
    public string ModelNamespaceName { get; }
    public ModelBuilderPropertyInfo[] Properties { get; }
}