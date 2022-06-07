using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamManager.Application.Permissions;
using TeamManager.Application.ProjectMembers.Commands.Create;

namespace TeamManager.API.Controllers
{
    public class ProjectMemberController : BaseController
    {
        [Authorize(Policy = Permission.ProjectMember.Create)]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateProjectMemberCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
