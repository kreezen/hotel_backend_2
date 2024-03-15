
using Task = Domain.Activities.Task;
using SharedKernel;

public class CreateTaskHandler : ICommandHandler<CreateTaskCommand, Task>
{
    private readonly ITaskRepository _taskRepository;
    public CreateTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<Task>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new Task
        {
            Description = request.Description,
            CreatedOn = request.CreatedOn,
            ModifiedOn = request.ModifiedOn,
            CreatedBy = request.CreatedBy,
            ModifiedBy = request.ModifiedBy,
            IsCompleted = request.IsCompleted,
            AssignedTo = request.AssignedTo,
            DueDate = request.DueDate
        };
        return await _taskRepository.CreateTaskAsync(task);
    }
}

