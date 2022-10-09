namespace SourceGen.Generators;

internal struct ToolInfo
{
    public ToolInfo(string name, string version)
    {
        Name = name;
        Version = version;
    }

    public string Name { get; }
    public string Version { get; }
}
