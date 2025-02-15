using FluentValidation;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Wiser.Identity.CQRS.Contracts.Users.Commands;

namespace Wiser.Identity.CQRS.Handlers.Users.ExpressionFilters
{
    public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            // Name: At least 2 characters, only letters and spaces allowed
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name can only contain letters and spaces.");

            // Email: Standard email format validation
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            // Password: If provided, it must be at least 8 characters, containing uppercase, lowercase, number, and special character
            RuleFor(x => x.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$")
                .WithMessage("Password must be at least 8 characters long, include uppercase, lowercase, a number, and a special character.")
                .When(x => !string.IsNullOrEmpty(x.Password)); // Only validate if not null

            // Phone: If provided, must be 7-15 digits long
            RuleFor(x => x.Phone)
                .Matches(@"^\d{7,15}$")
                .WithMessage("Phone number must be between 7 and 15 digits.")
                .When(x => !string.IsNullOrEmpty(x.Phone)); // Only validate if not null
        }
    }
}