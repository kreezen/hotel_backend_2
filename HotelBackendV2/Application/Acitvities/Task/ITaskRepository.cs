using Domain.Users;
using Task = Domain.Activities.Task;


public interface ITaskRepository
{
    Task<IEnumerable<Task?>> GetTasksByUserAsync(User user);
    Task<IEnumerable<Task>> GetTasksAsync();
    Task<Task> CreateTaskAsync(Task task);
    Task<Task?> getTaskByIdAsync(Guid id);
    Task<Task> updateTaskAsync(Task task);
    Task<List<Task>> GetAllTaksAsync();

}
