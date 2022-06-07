using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TeamManager.Domain.Entities.ProjectAggregation;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Application.Projects.Commands.Create
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, bool>
    {
        private readonly IRepository _repository;

        public CreateProjectCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Name,request.PmId );


            await _repository.Create(project);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
