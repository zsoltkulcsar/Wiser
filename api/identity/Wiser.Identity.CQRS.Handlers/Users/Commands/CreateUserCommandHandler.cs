using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Wiser.Common.Requests;
using Wiser.Identity.CQRS.Contracts.Users.Commands;
using Wiser.Identity.CQRS.Handlers.Users.Events;
using Wiser.Identity.Domain.Entities;
using Wiser.Identity.Repositories;

namespace ITP.Identity.CQRS.Handlers.Users.Commands
{
    public sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, IResult>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IMediator mediator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<IResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.AddAsync(user, cancellationToken);
            await _mediator.Publish(new UserAddedEvent() { Id = user.Id, Name = user.Name }, cancellationToken);

            return Results.Ok(new
            {
                user.Id
            });
        }
    }
}