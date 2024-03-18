
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Activities.Task;


public class TaskRepository : ITaskRepository
{
    private readonly HotelDbContext _dbContext;

    public TaskRepository(HotelDbContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<Task?>> GetTasksByUserAsync(User user)
    {
        return await _dbContext.Tasks
            .Include(t => t.AssignedTo)
            .Where(t => t.AssignedTo == user).ToListAsync();
    }

    public async Task<IEnumerable<Task>> GetTasksAsync()
    {
        return await _dbContext.Tasks.ToListAsync();
    }

    public async Task<Task> CreateTaskAsync(Task task)
    {
        task.CreatedOn = DateTime.UtcNow;
        task.ModifiedOn = DateTime.UtcNow;

        _dbContext.Tasks.Add(task);
        await _dbContext.SaveChangesAsync();
        return task;
    }

    public async Task<Task> updateTaskAsync(Task task)
    {
        _dbContext.Update(task);
        await _dbContext.SaveChangesAsync();
        return task;
    }

    public async Task<Task?> getTaskByIdAsync(Guid id)
    {
        return await _dbContext.Tasks.FirstOrDefaultAsync(t => t.CustomerId == id);
    }

}

