using MediatR;

namespace TeamManager.Application.Roles.Commands.Create
{
    public class CreateRoleCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
