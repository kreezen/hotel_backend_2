
using Domain.Users;
namespace Domain.Activities;
public class Task : Activity
{
    public required User AssignedTo { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }


}
