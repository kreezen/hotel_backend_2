
using Application.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly HotelDbContext _dbContext;

        public TaskRepository(HotelDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Taskk?>> GetTasksByUserAsync(User user)
        {
            return await _dbContext.Tasks
                .Include(t => t.AssignedTo)
                .Where(t => t.AssignedTo == user).ToListAsync();
        }

        public async Task<IEnumerable<Taskk>> GetTasksAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<Taskk> CreateTaskAsync(Taskk task)
        {
            task.CreatedOn = DateTime.UtcNow;
            task.ModifiedOn = DateTime.UtcNow;

            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }
    }
}
