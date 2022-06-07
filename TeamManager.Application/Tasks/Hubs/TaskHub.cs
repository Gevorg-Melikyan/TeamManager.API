using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace TeamManager.Application.Tasks.Commands.Hubs
{
    // [Authorize]
    public class TaskHub : Hub<ITaskClient>
    {
    }
}
