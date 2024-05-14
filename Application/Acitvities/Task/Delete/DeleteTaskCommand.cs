using Task = Domain.Activities.Task;
public class DeleteTaskCommand : ICommand<Task>
{
    public Guid Id { get; set; }
}