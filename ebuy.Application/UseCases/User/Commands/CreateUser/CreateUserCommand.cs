using ebuy.Domain.Notifications;

namespace ebuy.Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserCommand : Command<CreateUserCommandResponse>
    {
        public CreateUserCommand(CreateUserCommandRequest request) 
        {
            Request = request;
        }

        public CreateUserCommandRequest Request { get; set; }
    }
}
