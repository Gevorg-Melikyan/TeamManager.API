using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TeamManager.Domain.Enums;
using TeamManager.Domain.Exeptions;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Application.Tasks.Commands.Update

{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly IRepository _repository;
        private readonly IIdentityService _identityService;
        public UpdateTaskCommandHandler(IRepository repository, IIdentityService identityService)
        {
            _repository = repository;
            _identityService = identityService;
        }

        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityService.UserIdentity;
            var task = await _repository.GetByIdAsync<Domain.Entities.TaskAgregation.Task>(request.Id);
            if (task == null)
                throw new SmartException(string.Join(Environment.NewLine, "Test not found" + request.Id));

            var updatedtask = new Domain.Entities.TaskAgregation.Task(request.Id,request.Name,
                                      request.Description,
                                      request.ProjectId,
                                      request.ApplicationUserId,
                                      request.TaskState);

            if (userId.Equals(task) && request.TaskState== TaskState.Resolved)
            {
                task.Reslove(TaskState.Resolved);
            }

            await _repository.Update(updatedtask);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
