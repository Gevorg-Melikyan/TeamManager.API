using MediatR;
using TeamManager.Domain.Entities.TaskAgregation;

namespace TeamManager.Domain.Events
{
    public class TaskResolvedDomainEvent : INotification
    {
        public Task ResolvedTask { get; private set; }

        public TaskResolvedDomainEvent(Task resolvedTask)
        {
            ResolvedTask = resolvedTask;
        }
    }
}
