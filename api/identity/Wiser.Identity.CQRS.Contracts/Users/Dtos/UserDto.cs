namespace Wiser.Identity.CQRS.Contracts.Users.Dtos
{
    public sealed record UserDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = default!;

        public string Email { get; init; } = default!;

        public string Phone { get; init; } = default!;
    }
}
