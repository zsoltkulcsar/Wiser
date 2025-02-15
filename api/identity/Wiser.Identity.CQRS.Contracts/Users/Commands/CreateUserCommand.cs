using Microsoft.AspNetCore.Http;
using Wiser.Common.Requests;

namespace Wiser.Identity.CQRS.Contracts.Users.Commands
{
    public sealed record class CreateUserCommand : ICommand<IResult>
    {
        public string Name { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string? Password { get; init; }
        public string Phone { get; init; } = default!;
    }
}
