public class Task : Activity
{
    public required User AssignedTo { get; set; }
    public new DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}
