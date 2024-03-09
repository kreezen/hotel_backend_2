using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Entities;
using SharedKernel;

namespace Application.Task.GetByUser;

public class GetByUserQueryHandler : IQueryHandler<GetByUserQuery, IEnumerable<Taskk>>
{
    private readonly ITaskRepository _taskRepository;

    GetByUserQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<IEnumerable<Taskk>>> Handle(GetByUserQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetTasksByUserAsync(request.User);
        if (tasks == null)
        {
            return (Result<IEnumerable<Taskk>>)Result.Failure(Error.NotFound("Tasks.NotFound", "Tasks not found"));
        }
        return (Result<IEnumerable<Taskk>>)tasks;

    }
}