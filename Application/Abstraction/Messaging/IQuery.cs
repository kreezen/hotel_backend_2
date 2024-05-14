using MediatR;
using SharedKernel;



public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
