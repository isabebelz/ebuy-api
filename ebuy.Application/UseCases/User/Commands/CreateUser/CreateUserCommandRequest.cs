using MediatR;
using System.Text.Json.Serialization;

namespace ebuy.Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public required string Name { get; set; } 
        public required string Email { get; set; } 
        public required string Password { get; set; }
        [JsonIgnore]
        public required bool Active { get; set; }
    }
}
