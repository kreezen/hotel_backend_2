using SharedKernel;
using Task = Domain.Activities.Task;
public class UpdateTaskHandler : ICommandHandler<UpdateTaskCommand, Task>
{
    private readonly ITaskRepository _taskRepository;

    public UpdateTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<Task>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {

        var oldTask = await _taskRepository.getTaskByIdAsync(request.CustomerId);
        if (oldTask == null)
        {
            return (Result<Task>)Result.Failure(Error.NotFound("Task.NotFound", "Task not found"));
        }

        var updatedTask = new Task
        {
            Description = request.Description,
            ModifiedBy = request.ModifiedBy,
            CreatedBy = oldTask.CreatedBy,
            ModifiedOn = DateTime.Now,
            DueDate = request.DueDate,
            AssignedTo = request.AssignedTo,
            IsCompleted = request.IsCompleted
        };

        return await _taskRepository.updateTaskAsync(updatedTask);
    }
}