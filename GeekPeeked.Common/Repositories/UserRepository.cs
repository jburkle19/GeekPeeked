using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GeekPeeked.Common.Models;
using GeekPeeked.Common.Configuration;

namespace GeekPeeked.Common.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private IdentityRole _adminRole = null;

        private ApplicationUserManager _userManager;

        public UserRepository(GeekPeekedDbContext context, ApplicationUserManager userManager) : base(context)
        {
            _userManager = userManager;
        }

        public IdentityRole AdminRole
        {
            get
            {
                if (_adminRole == null)
                    _adminRole = _context.Roles.Where(x => x.Name == "Administrator").FirstOrDefault();

                return _adminRole;
            }
        }

        public async Task<ApplicationUser> Find(string id)
        {
            return await (from u in _context.Users where u.Id == id select u).FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> FindByEmail(string emailAddress)
        {
            return await (from u in _context.Users where u.Email == emailAddress select u).FirstOrDefaultAsync();
        }

        public async Task<int> Count(string searchTerm = "")
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await (from u in _context.Users
                              where u.LastName.Contains(searchTerm) || u.FirstName.Contains(searchTerm) || u.Email.Contains(searchTerm)
                              select u).CountAsync();
            }
            else
                return await (from u in _context.Users select u).CountAsync();
        }

        public async Task<int> NewUserCount()
        {
            var date = DateTime.Now.AddMonths(-1).Date;

            return await (from u in _context.Users where u.CreatedDate >= date select u).CountAsync();
        }

        public async Task<int> AdminCount(string searchTerm = "")
        {
            if (AdminRole == null)
                return 0;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await (from u in _context.Users
                              where u.Roles.Select(r => r.RoleId).Contains(AdminRole.Id)
                              where u.LastName.Contains(searchTerm) || u.FirstName.Contains(searchTerm) || u.Email.Contains(searchTerm)
                              select u).CountAsync();
            }
            else
                return await (from u in _context.Users where u.Roles.Select(r => r.RoleId).Contains(AdminRole.Id) select u).CountAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetActiveUsers(string sortField = "Name", string sortOrder = "asc", string searchTerm = "")
        {
            var users = from u in _context.Users select u;

            if (sortField == "Name")
                users = users.OrderBy(string.Format("LastName {0}, FirstName {0}", sortOrder));
            else if (sortField == "Role")
            {
                if (sortOrder.ToLower() == "asc")
                    users = users.OrderBy((m => m.Roles.Select(r => r.RoleId).FirstOrDefault()));
                else
                    users = users.OrderByDescending((m => m.Roles.Select(r => r.RoleId).FirstOrDefault()));
            }
            else
                users = users.OrderBy(string.Format("{0} {1}", sortField, sortOrder));

            if (!string.IsNullOrWhiteSpace(searchTerm))
                users = users.Where(x => x.FirstName.Contains(searchTerm) || x.LastName.Contains(searchTerm) || x.Email.Contains(searchTerm));

            return await (users.ToListAsync());
        }

        public async Task<IdentityResult> Save(ApplicationUser user, string newPassword = null)
        {
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                string hashedNewPassword = _userManager.PasswordHasher.HashPassword(newPassword);
                UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(_context);
                await store.SetPasswordHashAsync(user, hashedNewPassword);
            }

            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> Create(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> SetRole(ApplicationUser user, string role)
        {
            if (role == "Administrator")
            {
                if (!await _userManager.IsInRoleAsync(user.Id, role))
                    return await _userManager.AddToRoleAsync(user.Id, role);
                else
                    return IdentityResult.Success;
            }
            else
            {
                if (await _userManager.IsInRoleAsync(user.Id, "Administrator"))
                    return await _userManager.RemoveFromRoleAsync(user.Id, "Administrator");
                else
                    return IdentityResult.Success;
            }
        }
    }
}
