using FluentValidation;
using Wiser.Identity.CQRS.Contracts.Users.Commands;
using Wiser.Identity.CQRS.Contracts.Users.Dtos;

namespace Wiser.Identity.CQRS.Contracts.Users.Validators
{
    public sealed class CreateUserCommandValidator : AbstractValidator<AddUserDto>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name can only contain letters and spaces.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$")
                .WithMessage("Password must be at least 8 characters long, include uppercase, lowercase, a number, and a special character.")
                .When(x => !string.IsNullOrEmpty(x.Password));

            RuleFor(x => x.Phone)
                .Matches(@"^\d{7,15}$")
                .WithMessage("Phone number must be between 7 and 15 digits.")
                .When(x => !string.IsNullOrEmpty(x.Phone));
        }
    }
}