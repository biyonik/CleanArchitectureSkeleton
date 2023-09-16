using MediatR;

namespace CleanArchitectureSkeleton.Application.Messaging;

public interface IQuery<out TResponse>: IRequest<TResponse>
{
    
}