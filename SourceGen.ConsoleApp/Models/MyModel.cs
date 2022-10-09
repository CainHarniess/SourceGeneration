using SourceGen.Core.Attributes;

namespace SourceGen.ConsoleApp.Models;

[AutoBuilder]
public class MyNewModel
{
    public const string DO_NOT_CHANGE = "Fixed Value";
    public int PublicMemberField = 5;

    public Guid Id { get; set; }

    public string? Forenames { get; set; }
    public string? Surname { get; set; }
    public int Age { get; set; }
    public decimal TotalWealth { get; set; }
    public MyNewModel? Parent { get; set; }
    public IEnumerable<MyNewModel?>? Siblings { get; set; }
    public DateTime? DeletedDate { get; set; }
}
