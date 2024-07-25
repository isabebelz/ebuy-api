using ebuy.Application.Common.Interfaces.Repositories;
using ebuy.Domain.Interfaces;
using MediatR;

namespace ebuy.Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
