

using SharedKernel;
using Task = Domain.Activities.Task;


public class GetByUserQueryHandler : IQueryHandler<GetByUserQuery, IEnumerable<Task>>
{
    private readonly ITaskRepository _taskRepository;

    public GetByUserQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<IEnumerable<Task>>> Handle(GetByUserQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetTasksByUserAsync(request.User);
        if (tasks == null)
        {
            return Result.Failure<IEnumerable<Task>>(Error.NotFound("Tasks.NotFound", "Tasks not found"));
        }
        return (Result<IEnumerable<Task>>)tasks;

    }
}