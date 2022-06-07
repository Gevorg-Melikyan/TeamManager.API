using Microsoft.AspNetCore.Identity;

namespace TeamManager.Domain.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsDeleted { get; set; }
    }
}
