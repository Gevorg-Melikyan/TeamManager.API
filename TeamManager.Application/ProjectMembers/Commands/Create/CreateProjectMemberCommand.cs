using MediatR;

namespace TeamManager.Application.ProjectMembers.Commands.Create
{
    public class CreateProjectMemberCommand : IRequest<bool>
    {
        public long ProjectId { get; set; }
        public string TeamMemberId { get; set; }
        public string Possition { get; set; }

    }

}
