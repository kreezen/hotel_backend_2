using Application.Abstractions.Messaging;
using Domain.Entities;
using MediatR;
using SharedKernel;


namespace Application.Task.GetByUser
{
    public class GetByUserQuery : IQuery<IEnumerable<Taskk>>
    {
        public required User User { get; set; }
    }
}
