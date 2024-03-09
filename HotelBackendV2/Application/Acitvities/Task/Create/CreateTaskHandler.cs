using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Entities;
using SharedKernel;

namespace Application.Task.Create
{
    public class CreateTaskHandler : ICommandHandler<CreateTaskCommand, Taskk>
    {
        private readonly ITaskRepository _taskRepository;
        public CreateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Result<Taskk>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Taskk
            {
                Description = request.Description,
                CreatedOn = request.CreatedOn,
                ModifiedOn = request.ModifiedOn,
                CreatedBy = request.CreatedBy,
                ModifiedBy = request.ModifiedBy,
                IsCompleted = request.IsCompleted,
                AssignedTo = request.AssignedTo,
                DueDate = request.DueDate
            };
            return await _taskRepository.CreateTaskAsync(task);
        }
    }
}
