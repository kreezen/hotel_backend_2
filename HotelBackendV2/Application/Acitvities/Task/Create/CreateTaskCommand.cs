using Application.Abstractions.Messaging;
using Domain.Entities;


namespace Application.Task.Create
{
    public class CreateTaskCommand : ICommand<Taskk>
    {
        public required string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime DueDate { get; set; }
        public required User CreatedBy { get; set; }
        public required User ModifiedBy { get; set; }
        public Boolean IsCompleted { get; set; }
        public required User AssignedTo { get; set; }

    }
}
