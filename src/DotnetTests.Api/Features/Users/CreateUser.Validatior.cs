using FluentValidation;

namespace DotnetTests.Api.Features.Users;

public class CreateUserValidator : Validator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(c => c.Age)
            .NotEmpty()
            .WithMessage("Age is required")
            .GreaterThan(18)
            .WithMessage("You must be 18 or older");
    }
}
