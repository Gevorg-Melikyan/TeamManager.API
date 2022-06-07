using FluentValidation;

namespace TeamManager.Application.ProjectMembers.Commands.Create
{
    public class CreateProjectMemberCommandValidator : AbstractValidator<CreateProjectMemberCommand>
    {
        public CreateProjectMemberCommandValidator()
        {
            RuleFor(x => x.ProjectId).NotEmpty();
            RuleFor(X => X.TeamMemberId).NotEmpty();
        }
    }
}
