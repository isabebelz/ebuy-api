using FluentValidation;

namespace ebuy.Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Request.Name)
                .NotNull().NotEmpty()
                .WithMessage("O campo Nome é obrigatório.");

            RuleFor(u => u.Request.Password)
                .NotNull().NotEmpty()
                .WithMessage("O campo Senha é obrigatório.");

            RuleFor(u => u.Request.Email)
                .NotNull().NotEmpty()
                .WithMessage("O campo Email é obrigatório.");
        }
    }
}
