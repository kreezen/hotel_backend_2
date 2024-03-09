
namespace Domain.Entities;
public class Taskk : Activity
{
    public required User AssignedTo { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}
