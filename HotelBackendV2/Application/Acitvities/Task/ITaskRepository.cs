using Domain.Entities;
namespace Application.Abstractions.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<Taskk?>> GetTasksByUserAsync(User user);
    Task<IEnumerable<Taskk>> GetTasksAsync();
    Task<Taskk> CreateTaskAsync(Taskk task);

}
