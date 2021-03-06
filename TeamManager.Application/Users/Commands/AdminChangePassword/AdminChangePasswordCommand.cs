using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TeamManager.Application.Users.Commands.ChangePassword
{
    public class AdminChangePasswordCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
