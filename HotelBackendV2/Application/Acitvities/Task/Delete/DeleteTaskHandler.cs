using SharedKernel;
using Task = Domain.Activities.Task;
public class DeleteTaskHandler : ICommandHandler<DeleteTaskCommand, Task>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<Task>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetTaskByIdAsync(request.Id);

        if (task == null)
        {
            return Result.Failure<Task>(Error.NotFound("Task.NotFound", "Task not found"));
        }
        await _taskRepository.DeleteTaskAsync(request.Id);
        return task;
    }
}