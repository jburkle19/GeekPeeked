using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekPeeked.Common.Models;

namespace GeekPeeked.Common.Repositories
{
    public interface IUserRepository : IBaseRepository
    {
        IdentityRole AdminRole { get; }
        Task<int> Count(string searchTerm = "");
        Task<int> AdminCount(string searchTerm = "");
        Task<int> NewUserCount();
        Task<ApplicationUser> Find(string id);
        Task<ApplicationUser> FindByEmail(string emailAddress);

        Task<IEnumerable<ApplicationUser>> GetActiveUsers(string sortField = "Name", string sortOrder = "asc", string searchTerm = "");

        Task<IdentityResult> Create(ApplicationUser user, string password);
        Task<IdentityResult> Save(ApplicationUser user, string newPassword = null);
        Task<IdentityResult> SetRole(ApplicationUser user, string role);
    }
}
