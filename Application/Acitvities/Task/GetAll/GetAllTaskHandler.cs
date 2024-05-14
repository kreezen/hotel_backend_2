using MediatR;
using SharedKernel;
using Task = Domain.Activities.Task;

public class GetAllTaskHandler : IQueryHandler<GetAllTaskQuery, List<Task>>
{

    private readonly ITaskRepository _taskRepository;

    public GetAllTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<Result<List<Task>>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
    {
        return await _taskRepository.GetAllTaksAsync();
    }

}