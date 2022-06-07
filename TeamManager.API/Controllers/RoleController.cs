using TeamManager.Application.Permissions;
using TeamManager.Application.Roles.Commands.AddClaimToRole;
using TeamManager.Application.Roles.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TeamManager.API.Controllers
{
    public class RoleController : BaseController
    {
        [Authorize(Policy = Permission.Roles.Create)]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateRoleCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize(Policy = Permission.Roles.Edit)]
        [HttpPost]
        public async Task<IActionResult> AddClaimToRole([FromBody] AddClaimToRoleCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
