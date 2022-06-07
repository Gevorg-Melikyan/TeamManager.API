using MediatR;
using TeamManager.Domain.Enums;

namespace TeamManager.Application.Tasks.Commands.Update
{
    public class UpdateTaskCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ProjectId { get; set; }
        public string ApplicationUserId { get; set; }
        public TaskState TaskState { get; set; }

    }

}
