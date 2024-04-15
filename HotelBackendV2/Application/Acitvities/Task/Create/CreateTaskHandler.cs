
using Task = Domain.Activities.Task;
using SharedKernel;
using System.Data;
using Domain.Users;

public class CreateTaskHandler : ICommandHandler<CreateTaskCommand, Task>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    public CreateTaskHandler(ITaskRepository taskRepository, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<Task>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var createdBy = await _userRepository.GetByIdAsync(request.CreatedBy.Id);
        var assignedTo = await _userRepository.GetByIdAsync(request.AssignedTo.Id);

        if (createdBy == null || assignedTo == null)
        {
            return (Result<Task>)Result.Failure(Error.NotFound("User.NotFound", "User not found"));
        }

        var task = new Task
        {
            CustomerId = request.CustomerId,
            Description = request.Description,
            CreatedOn = DateTime.UtcNow,
            ModifiedOn = DateTime.UtcNow,
            CreatedBy = createdBy,
            ModifiedBy = createdBy,
            IsCompleted = false,
            AssignedTo = assignedTo,
            DueDate = request.DueDate
        };
        return await _taskRepository.CreateTaskAsync(task);
    }
}

