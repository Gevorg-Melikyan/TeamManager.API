using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TeamManager.Domain.Exeptions;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Application.Tasks.Commands.Update

{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly IRepository _repository;
        public UpdateTaskCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {


            var task = await _repository.GetByIdAsync<Domain.Entities.TaskAgregation.Task>(request.Id);
            if (task == null)
                throw new SmartException(string.Join(Environment.NewLine, "Test not found" + request.Id));

            var updatedtask = new Domain.Entities.TaskAgregation.Task(request.Id,request.Name,
                                      request.Description,
                                      request.ProjectId,
                                      request.ApplicationUserId,
                                      request.TaskState);

            await _repository.Update(updatedtask);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
