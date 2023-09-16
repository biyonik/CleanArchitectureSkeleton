using MediatR;

namespace CleanArchitectureSkeleton.Application.Messaging;

public interface ICommand<out TResponse>: IRequest<TResponse>
{
    
}