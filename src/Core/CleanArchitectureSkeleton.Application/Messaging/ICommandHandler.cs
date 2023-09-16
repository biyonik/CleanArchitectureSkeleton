using MediatR;

namespace CleanArchitectureSkeleton.Application.Messaging;

public interface ICommandHandler<in TCommand, TResponse>: IRequestHandler<TCommand, TResponse> where TCommand : IRequest<TResponse>
{
    
}