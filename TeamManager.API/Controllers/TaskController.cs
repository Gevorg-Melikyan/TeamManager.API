using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamManager.Application.Permissions;
using TeamManager.Application.Tasks.Commands.Create;

namespace TeamManager.API.Controllers
{
    public class TaskController : BaseController
    {
        [Authorize(Policy = Permission.Task.Create)]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateTaskCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
