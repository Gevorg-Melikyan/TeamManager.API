using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TeamManager.Domain.Entities.ProjectAggregation;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Application.ProjectMembers.Commands.Create
{
    public class CreateProjectMemberCommandHandler : IRequestHandler<CreateProjectMemberCommand, bool>
    {
        private readonly IRepository _repository;
        public CreateProjectMemberCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var member = new ProjectMember(request.Possition,
                                      request.TeamMemberId,
                                      request.ProjectId);



            await _repository.Create(member);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
