public interface ITaskRepository
{
    Task<IEnumerable<Activity?>> GetTaskByUserAsync(User user);
    Task<IEnumerable<Activity>> GetTasksAsync();
    Task<Activity> CreateTaskAsync(Task task);

}
