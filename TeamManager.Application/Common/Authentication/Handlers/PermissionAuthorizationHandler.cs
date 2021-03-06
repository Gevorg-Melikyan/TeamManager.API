using TeamManager.Application.Common.Authentication.Requirements;
using TeamManager.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace TeamManager.Application.Common.Authentication.Handlers
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
                return;

            bool IsInPerm = context.User.Claims
                .Any(x => x.Type == CustomClaimTypes.Permission && x.Value == requirement.Permission);
            if (IsInPerm)
            {
                context.Succeed(requirement);
            }

            await Task.CompletedTask;
        }
    }
}

