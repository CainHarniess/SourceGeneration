using SourceGen.Core.Attributes;
using System.CodeDom.Compiler;

namespace SourceGen.DataAccess;

[AutoBuilder]
[GeneratedCode("BuildableGenerator", "0.0.1")]
public class MyModelEntity : MyEntityBase
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int Age { get; set; }
    public decimal TotalWealth { get; set; }
    public virtual ICollection<MyChildEntity> RelatedEntities { get; set; } = Array.Empty<MyChildEntity>();
    
}
