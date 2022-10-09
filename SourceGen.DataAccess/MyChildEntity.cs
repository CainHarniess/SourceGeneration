using SourceGen.Core.Attributes;

namespace SourceGen.DataAccess;

public class MyChildEntity : MyEntityBase
{
    public Guid ParentId { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }

}
