using MediatR;
using System;

namespace TeamManager.Application.Projects.Commands.Create
{
    public class CreateProjectCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string PmId { get; set; }
    }

}
