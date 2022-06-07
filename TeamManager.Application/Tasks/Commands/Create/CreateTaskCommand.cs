using MediatR;
using TeamManager.Domain.Enums;

namespace TeamManager.Application.Tasks.Commands.Create
{
    public class CreateTaskCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long ProjectId { get; set; }
        public string ApplicationUserId { get; set; }
        public TaskState TaskState { get; set; }

    }

}
