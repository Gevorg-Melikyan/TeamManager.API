using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamManager.Application.Permissions;
using TeamManager.Application.Projects.Commands.Create;

namespace TeamManager.API.Controllers
{
    public class ProjectController : BaseController
    {
        [Authorize(Policy = Permission.Project.Create)]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateProjectCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
