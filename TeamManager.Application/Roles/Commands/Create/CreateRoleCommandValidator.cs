using FluentValidation;

namespace TeamManager.Application.Roles.Commands.Create
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}