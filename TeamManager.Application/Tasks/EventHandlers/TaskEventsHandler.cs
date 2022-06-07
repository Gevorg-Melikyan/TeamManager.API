using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TeamManager.Application.Roles;
using TeamManager.Application.Tasks.Commands.Hubs;
using TeamManager.Domain.Events;
using TeamManager.Domain.Identity;

namespace TeamManager.Application.Tasks.Commands.EventHandlers
{
    public class TaskEventsHandler : INotificationHandler<TaskResolvedDomainEvent>
    {
        private readonly IHubContext<TaskHub, ITaskClient> _hubContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public TaskEventsHandler(IHubContext<TaskHub, ITaskClient> hubContext, UserManager<ApplicationUser> userManager)
        {
            _hubContext = hubContext;
            _userManager = userManager;
        }

        public async Task Handle(TaskResolvedDomainEvent notification, CancellationToken cancellationToken)
        {
            var users = await _userManager.GetUsersInRoleAsync(Role.User.ToString());
            var userIds = users.Select(x => x.Id).ToList();
            await _hubContext.Clients.Users(userIds).ProductDiscounted(new
            {
                TaskId = notification.ResolvedTask.Id,
                TaskState = notification.ResolvedTask.TaskState,

            });
        }
    }
}
