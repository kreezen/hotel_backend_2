using SharedKernel;
using Task = Domain.Activities.Task;
public class UpdateTaskHandler : ICommandHandler<UpdateTaskCommand, Task>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;

    public UpdateTaskHandler(ITaskRepository taskRepository, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<Task>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {

        var oldTask = await _taskRepository.GetTaskByIdAsync(request.Id);
        if (oldTask == null)
        {
            return (Result<Task>)Result.Failure(Error.NotFound("Task.NotFound", "Task not found"));
        }

        var modifiedBy = await _userRepository.GetByIdAsync(request.ModifiedBy.Id);
        var assignedTo = await _userRepository.GetByIdAsync(request.AssignedTo.Id);

        if (modifiedBy == null || assignedTo == null)
        {
            return (Result<Task>)Result.Failure(Error.NotFound("User.NotFound", "User not found"));
        }

        oldTask.ModifiedOn = DateTime.UtcNow;
        oldTask.Description = request.Description;
        oldTask.ModifiedBy = modifiedBy;
        oldTask.DueDate = request.DueDate;
        oldTask.AssignedTo = assignedTo;
        oldTask.IsCompleted = request.IsCompleted;

        await _taskRepository.SaveChangesAsync();
        return (Result<Task>)oldTask;
    }
}