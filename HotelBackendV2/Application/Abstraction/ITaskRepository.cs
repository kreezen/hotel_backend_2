using Domain.Entities;

public interface ITaskRepository
{
    Task<IEnumerable<Taskk?>> GetTaskByUserAsync(User user);
    Task<IEnumerable<Taskk>> GetTasksAsync();
    Task<Taskk> CreateTaskAsync(Taskk task);

}
