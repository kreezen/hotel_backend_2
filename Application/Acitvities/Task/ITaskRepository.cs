using Domain.Users;
using Task = Domain.Activities.Task;


public interface ITaskRepository
{
    Task<IEnumerable<Task?>> GetTasksByUserAsync(User user);
    Task<IEnumerable<Task>> GetTasksAsync();
    Task<Task> CreateTaskAsync(Task task);
    Task<Task?> GetTaskByIdAsync(Guid id);
    Task<int> SaveChangesAsync();
    Task<List<Task>> GetAllTaksAsync();
    Task<int> DeleteTaskAsync(Guid id);
}
