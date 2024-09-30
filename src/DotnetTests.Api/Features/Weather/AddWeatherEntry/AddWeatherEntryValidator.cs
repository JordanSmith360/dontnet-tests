using FluentValidation;

namespace dotnet_tests.Features.Weather.AddWeatherEntry;

public class AddWeatherEntryValidator : Validator<AddWeatherEntryRequest>
{
    public AddWeatherEntryValidator()
    {
        RuleFor(x => x.Temperature)
            .NotEmpty()
            .WithMessage("temperature is required")
            .GreaterThan(-50)
            .WithMessage("temperature needs to be higher than -50C")
            .LessThan(100)
            .WithMessage("temperature needs to be less than 100C");

        RuleFor(x => x.Summary)
            .NotEmpty()
            .WithMessage("summary value is required")
            .MaximumLength(50)
            .WithMessage("summary length must be less than 50 characters long");
    }
}
