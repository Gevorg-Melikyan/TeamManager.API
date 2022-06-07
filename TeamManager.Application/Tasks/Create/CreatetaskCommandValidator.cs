using FluentValidation;

namespace TeamManager.Application.Tasks.Commands.Create

{
    public class CreatetaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreatetaskCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(X => X.Description).NotEmpty();
            RuleFor(X => X.ProjectId).NotEmpty();
            RuleFor(X => X.ApplicationUserId).NotEmpty();

        }
    }
}
