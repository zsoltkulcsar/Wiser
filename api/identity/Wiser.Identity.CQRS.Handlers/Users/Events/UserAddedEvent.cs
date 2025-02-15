using MediatR;

namespace Wiser.Identity.CQRS.Handlers.Users.Events
{
    public sealed record UserAddedEvent : INotification
    {
        public Guid Id { get; set; } = default!;

        public string Name { get; set; } = default!;
    }
}
