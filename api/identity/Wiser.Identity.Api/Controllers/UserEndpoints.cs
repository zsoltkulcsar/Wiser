using Microsoft.AspNetCore.Identity;
using Wiser.Identity.Domain.Entities;
using Wiser.Identity.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace Wiser.Identity.Api.Controllers
{
    public static class UserEndpoints
    {
        public static WebApplication AddUserEndpoints(this WebApplication webApplication)
        {
            webApplication.MapPost("/users", CreateUser)
                .RequireAuthorization()
                .Produces<Guid>()
                .WithTags(nameof(UserEndpoints))
                .WithName(nameof(CreateUser)).WithOpenAi();

            return webApplication;
        }

        private static async Task<IResult> CreateUser(
            IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher,
            User createUserRequest)
        {
            var user = new User
            {
                Name = createUserRequest.Name,
                Email = createUserRequest.Email
            };

            user.Password = passwordHasher.HashPassword(user, createUserRequest.Password);

            var result = await userRepository.CreateUserAsync(user, createUserRequest.Password);

            if (result.Succeeded)
            {
                return Results.Ok(user.Id);
            }

            return Results.BadRequest(new { Message = "Failed to create user" });
        }
    }
}