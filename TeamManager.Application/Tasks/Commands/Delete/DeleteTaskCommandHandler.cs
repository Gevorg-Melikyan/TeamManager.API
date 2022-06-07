using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TeamManager.Domain.Exeptions;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Application.Tasks.Commands.Delete

{
    public class DeleteTaskCommand : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IRepository _repository;
        public DeleteTaskCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {

            var task = await _repository.GetByIdAsync<Domain.Entities.TaskAgregation.Task>(request.Id);
            if (task == null)
                throw new SmartException(string.Join(Environment.NewLine, "Test not found" + request.Id));

            await _repository.Remove<Domain.Entities.TaskAgregation.Task>(request.Id);

            await _repository.CompleteAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
