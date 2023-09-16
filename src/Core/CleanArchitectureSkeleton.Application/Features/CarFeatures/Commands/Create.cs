using CleanArchitectureSkeleton.Domain.DTOs;
using CleanArchitectureSkeleton.Domain.DTOs.Car;
using MediatR;

namespace CleanArchitectureSkeleton.Application.Features.CarFeatures.Commands;

public sealed class Create
{
    public sealed record Command(AddForCarDto AddForCarDto) : IRequest<MessageResponse>;
    
    public sealed class Handler : IRequestHandler<Command, MessageResponse>
    {
        public async Task<MessageResponse> Handle(Command request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new MessageResponse($"Car {request.AddForCarDto.Name} created successfully"));
        }
    }
}