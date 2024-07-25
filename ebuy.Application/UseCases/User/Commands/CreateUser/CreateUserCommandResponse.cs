namespace ebuy.Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserCommandResponse
    {
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public bool? Active { get; private set; }
    }
}
