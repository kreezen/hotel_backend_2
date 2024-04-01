
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

        var task = new Task
        {
            CustomerId = request.CustomerId,
            Description = request.Description,
            CreatedOn = DateTime.UtcNow,
            ModifiedOn = DateTime.UtcNow,
            CreatedBy = _userRepository.AttachUser(request.CreatedBy).Entity,
            ModifiedBy = request.CreatedBy,
            IsCompleted = false,
            AssignedTo = request.AssignedTo.Equals(request.CreatedBy)
                            ? _userRepository.AttachUser(request.CreatedBy).Entity : request.AssignedTo,
            DueDate = request.DueDate
        };
        return await _taskRepository.CreateTaskAsync(task);
    }
}

