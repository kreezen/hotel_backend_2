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

        var oldTask = await _taskRepository.getTaskByIdAsync(request.Id);
        if (oldTask == null)
        {
            return (Result<Task>)Result.Failure(Error.NotFound("Task.NotFound", "Task not found"));
        }

        oldTask.ModifiedOn = DateTime.UtcNow;
        oldTask.Description = request.Description;
        oldTask.ModifiedBy = request.ModifiedBy;
        oldTask.DueDate = request.DueDate;
        oldTask.AssignedTo = request.AssignedTo;
        oldTask.IsCompleted = request.IsCompleted;

        /* var updatedTask = new Task
        {
            Id = oldTask.Id,
            Description = request.Description,
            ModifiedBy = request.ModifiedBy,
            CreatedBy = oldTask.CreatedBy,
            ModifiedOn = DateTime.UtcNow,
            DueDate = request.DueDate,
            AssignedTo = request.AssignedTo,
            IsCompleted = request.IsCompleted
        }; */

        return await _taskRepository.updateTaskAsync(oldTask);
    }
}