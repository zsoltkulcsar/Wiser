using Microsoft.AspNetCore.Http;
using Wiser.Common.Requests;
using Wiser.Identity.CQRS.Contracts.Users.Dtos;

namespace Wiser.Identity.CQRS.Contracts.Users.Commands
{
    public sealed record CreateUserCommand(AddUserDto AddUserDto) : ICommand<IResult>
    {
    }
}
