using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamManager.Application.Permissions;
using TeamManager.Application.Tasks.Commands.Create;
using TeamManager.Application.Tasks.Commands.Delete;
using TeamManager.Application.Tasks.Commands.Update;

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
        [Authorize(Policy = Permission.Task.Edit)]
        [HttpPost]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateTaskCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        [Authorize(Policy = Permission.Task.Delete)]
        [HttpPost]
        public async Task<ActionResult<bool>> Delete([FromBody] DeleteTaskCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
