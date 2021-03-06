using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamManager.Domain.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateEncodedToken(string id, string userName, IEnumerable<string> roles, IEnumerable<string> roleClaims = default);
    }
}
