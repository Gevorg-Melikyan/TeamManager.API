using System.Threading.Tasks;

namespace TeamManager.Application.Tasks.Commands.Hubs
{
    public interface ITaskClient
    {
        Task ProductDiscounted(object message);
    }
}
