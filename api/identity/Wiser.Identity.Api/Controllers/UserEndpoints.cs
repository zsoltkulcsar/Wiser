using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wiser.Identity.Api.Utils;
using Wiser.Identity.CQRS.Contracts.Users.Commands;
using Wiser.Identity.CQRS.Handlers.Users.ExpressionFilters;


namespace Wiser.Identity.Api.Controllers
{
    internal static class UserEndpoints
    {
        public static WebApplication AddUserEndpoints(this WebApplication webApplication)
        {
            webApplication.MapPost("/users", CreateUser)
                .RequireAuthorization()
                .Produces<Guid>()
                .WithTags(nameof(UserEndpoints))
                .WithName(nameof(CreateUser))
                .WithOpenApi();

            return webApplication;
        }

        private static async Task<IResult> CreateUser([FromServices] IMediator mediator, [AsParameters] CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(CreateUserCommand.AddEmployeeDto, cancellationToken).ConfigureAwait(false);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var createdUserId = await mediator.Send(CreateUserCommand, cancellationToken);

            if (createdUserId is null)
            {
                return Results.Conflict();
            }

            string uri = $"/{RouteNameConstants.Users}/{createdUserId}";
            return Results.Created(uri, createdUserId);
        }
    }
}