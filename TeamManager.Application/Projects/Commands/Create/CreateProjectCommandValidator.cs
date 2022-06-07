using FluentValidation;

namespace TeamManager.Application.Projects.Commands.Create
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PmId).NotEmpty();
        }
    }
}
