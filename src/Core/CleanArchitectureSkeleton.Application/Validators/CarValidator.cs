using CleanArchitectureSkeleton.Application.Features.CarFeatures.DTOs;
using FluentValidation;

namespace CleanArchitectureSkeleton.Application.Validators;

public class CarValidator : AbstractValidator<AddForCarDto>
{
    public CarValidator()
    {
        RuleFor(car => car.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters");
        
        RuleFor(car => car.Model)
            .NotEmpty().WithMessage("Model is required")
            .MaximumLength(50).WithMessage("Model must not exceed 50 characters");
        
        RuleFor(car => car.HorsePower)
            .NotEmpty().WithMessage("HorsePower is required")
            .GreaterThan(0).WithMessage("HorsePower must be greater than 0");
    }
}