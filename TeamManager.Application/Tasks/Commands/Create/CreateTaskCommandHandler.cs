using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Application.Tasks.Commands.Create

{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, bool>
    {
        private readonly IRepository _repository;
        public CreateTaskCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Domain.Entities.TaskAgregation.Task(request.Name,
                                      request.Description,
                                      request.ProjectId,
                                      request.ApplicationUserId,
                                      request.TaskState);

            await _repository.Create(task);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
