using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace SourceGen.Generators;

internal class SourceGenerationResult
{
    public SourceGenerationResult(string fileName, string sourceTest)
        : this(fileName, SourceText.From(sourceTest, Encoding.UTF8))
    {

    }

    public SourceGenerationResult(string fileName, SourceText sourceText)
    {
        FileName = fileName;
        SourceText = sourceText;
    }

    public string FileName { get; }
    public SourceText SourceText { get; }
}
