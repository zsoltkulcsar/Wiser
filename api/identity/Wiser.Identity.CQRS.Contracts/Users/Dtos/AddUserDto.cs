namespace Wiser.Identity.CQRS.Contracts.Users.Dtos
{
    public sealed record AddUserDto
    {
        public string Name { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string? Password { get; init; }
        public string Phone { get; init; } = default!;
    }
}
