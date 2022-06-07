using FluentValidation;

namespace TeamManager.Application.Tasks.Commands.Update

{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(X => X.Description).NotEmpty();
            RuleFor(X => X.ProjectId).NotEmpty();
            RuleFor(X => X.ApplicationUserId).NotEmpty();
            RuleFor(x=>x.Id).NotEmpty();


        }
    }
}
