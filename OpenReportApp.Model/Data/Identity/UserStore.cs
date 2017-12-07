using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNet.Identity;
using OpenReportApp.Model.Entities.Identity;
using OpenReportApp.Model.DataContext;


namespace OpenReportApp.Model.Data.Identity
{
    public class UserStore <TUser> :
                        IUserStore<User, int>,
                        IUserRoleStore<User, int>,
                        IUserPasswordStore<User, int>,
                        IUserSecurityStampStore<User, int>,
                        IUserClaimStore<User, int>,
                        IQueryableUserStore<User, int>,
                        IUserEmailStore<User, int>,
                        IUserPhoneNumberStore<User, int>,
                        IUserLockoutStore<User, int>,
                        IUserTwoFactorStore<User, int>
                        where TUser :User
    {

        #region private
        private ReportDbContext Context;
        #endregion

        /// <summary>
        /// Constructor that takes a dbmanager as argument 
        /// </summary>
        /// <param name="database"></param>
        public UserStore(ReportDbContext dbcontext)
        {
            if (dbcontext != null)
            {
                Context = dbcontext;
            }
        }

        public void Dispose()
        {
            //if (Context != null)
            //{
            //    Context.Dispose();
            //    Context = null;
            //}
        }

        #region IUserStore
        public async Task CreateAsync(User user)
        {
            var result = await FindByEmailAsync(user.Email);
            if (result == null)
            {
                await Context.DB.Users.InsertAsync(user);
            }
        }

        public async Task UpdateAsync(User user)
        {
            await Context.DB.Users.UpdateAsync(user.Id, user);
        }

        public async Task DeleteAsync(User user)
        {
            //Update User Active Status. Keep user record in DB
            user.Active = false;
            user.ModifyDate = DateTime.Now;
            await UpdateAsync(user);
            //await database.Users.DeleteAsync(user.Id);
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            return (await Context.DB.QueryAsync<User>(@"select * from Users where Id=@Id", new { Id = userId })).SingleOrDefault();
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return (await Context.DB.QueryAsync<User>(@"select * from Users where UserName=@Name", new { Name = userName })).SingleOrDefault();
        }

        #endregion

        #region IUserEmailStore
        public async Task<User> FindByEmailAsync(string email)
        {
            return (await Context.DB.QueryAsync<User>(@"select * from Users where Email=@Email", new { Email = email })).SingleOrDefault();
        }

        public Task<string> GetEmailAsync(User user)
        {
            //return (await database.Users.GetAsync(user.Id)).Email;
            return Task.FromResult(user.Email);
        }

        public async Task SetEmailAsync(User user, string email)
        {
            User u = await Context.DB.Users.GetAsync(user.Id);
            if (user != null)
            {
                user.Email = email;

                await Context.DB.Users.UpdateAsync(u.Id, u);
            }
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            return Task.FromResult(true);
            //throw new NotImplementedException();
        }
        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            return Task.FromResult(0);
            //throw new NotImplementedException();
        }
        #endregion

        #region IUserPhoneNumberStore
        public Task<string> GetPhoneNumberAsync(User user)
        {
            return Task.FromResult(user.PhoneNumber);
            //return (await database.Users.GetAsync(user.Id)).PhoneNumber;
        }

        public async Task SetPhoneNumberAsync(User user, string phoneNumber)
        {
            User u = await Context.DB.Users.GetAsync(user.Id);

            if (user != null)
            {
                user.PhoneNumber = phoneNumber;

                await Context.DB.Users.UpdateAsync(u.Id, u);
            }
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user)
        {
            return Task.FromResult(true);
        }
        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed)
        {
            return Task.FromResult(0);
        }
        #endregion

        #region IUserSecurityStampStore

        public async Task<string> GetSecurityStampAsync(User user)
        {
            return (await Context.DB.Users.GetAsync(user.Id)).SecurityStamp;
        }

        public Task SetSecurityStampAsync(User user, string stamp)
        {
            //User u = await database.Users.GetAsync(user.Id);
            if (user != null)
            {
                user.SecurityStamp = stamp;
            }
            //await database.Users.UpdateAsync(u.Id, u);
            return Task.FromResult(0);

        }
        #endregion

        #region IQueryableUserStore
        public IQueryable<User> Users
        {
            get
            {
                return Context.DB.Users.All().AsQueryable();
            }
        }
        #endregion

        #region IUserPasswordStore

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
            //return (await database.Users.GetAsync(user.Id)).PasswordHash;
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            //Dont do DB.GetUser since User is not inserted yet. Also dont do Db.UpdateUser since ID will be zero.
            //User u = await database.Users.GetAsync(user.Id);
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            //Dont do DB.GetUser since User is not inserted yet. Also dont do Db.UpdateUser since ID will be zero.
            //User u = await database.Users.GetAsync(user.Id);
            if (user != null)
            {
                user.PasswordHash = passwordHash;
                //await database.Users.UpdateAsync(u.Id, u);
            }
            return Task.FromResult(0);
        }
        #endregion

        #region IUserRoleStore
        public async Task AddToRoleAsync(User user, string roleName)
        {
            Role role = (await Context.DB.QueryAsync<Role>(@"select * from Roles where Name=@RoleName", new { RoleName = roleName })).SingleOrDefault();
            if (role == null)
            {
                throw new InvalidOperationException(string.Format("Role {0} not found.", roleName));
            }

            var instance = new UserRole
            {
                RoleId = role.Id,
                UserId = user.Id,
            };

            await Context.DB.UserRoles.InsertAsync(instance);
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            return (await Context.DB
                    .QueryAsync<Role>(@"select R.* from UserRoles UR inner join Roles R on UR.RoleId=R.Id where UR.UserId=@UserId", new { UserId = user.Id }))
                    .Select(x => x.Name)
                    .ToList();
        }
        public async Task<bool> IsInRoleAsync(User user, string roleName)
        {
            return (await Context.DB
                    .QueryAsync<Role>(@"select R.* from UserRoles UR inner join Roles R on UR.RoleId=R.Id where UR.UserId=@UserId and R.Name=@RoleName", new { UserId = user.Id, RoleName = roleName }))
                    .Count() == 1;
        }
        //public async Task<IList<string>> GetRolesAsync(User user)
        //{
        //    List<Role> roles = (await database
        //            .QueryAsync<Role>(@"select R.* from UserRoles UR inner join Roles R on UR.RoleId=R.Id where UR.UserId=@UserId", new { UserId = user.Id }));
        //    {
        //        if (roles != null && roles.Count > 0)
        //        {
        //            return Task.FromResult<IList<string>>(roles.Select(role => (string)role.Name).ToList());
        //        }
        //    }
        //    return Task.FromResult<IList<string>>(null);
        //}
        //public Task<bool> IsInRoleAsync(User user, string roleName)
        //{
        //    List<Role> roles = (database
        //                    .QueryAsync<Role>(@"select R.* from UserRoles UR inner join Roles R on UR.RoleId=R.Id where UR.UserId=@UserId and R.Name=@RoleName", new { UserId = user.Id, RoleName = roleName })).Result;
        //    {
        //        if (roles != null && roles.Count>0)
        //        {
        //            return Task.FromResult<bool>(true);
        //        }
        //    }

        //    return Task.FromResult<bool>(false);
        //}
        public async Task RemoveFromRoleAsync(User user, string roleName)
        {
            Role role = (await Context.DB.QueryAsync<Role>(@"select * from Roles where Name=@RoleName", new { RoleName = roleName })).SingleOrDefault();
            if (role == null)
            {
                throw new InvalidOperationException(string.Format("Role {0} not found.", roleName));
            }

            await Context.DB.ExecuteAsync("delete UR from UserRoles UR inner join Roles R on UR.RoleId=R.Id where UR.UserId=@UserId and R.Name=@RoleName", new { UserId = user.Id, RoleName = roleName }).ConfigureAwait(false);
        }
        #endregion

        #region IUserClaimStore
        public async Task AddClaimAsync(User user, Claim claim)
        {
            var instance = new UserClaim
            {
                UserId = user.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value,
            };

            await Context.DB.UserClaims.InsertAsync(instance);
        }

        public async Task<IList<Claim>> GetClaimsAsync(User user)
        {
            return (await Context.DB
                    .QueryAsync<UserClaim>(@"select * from UserClaims where UserId=@UserId", new { UserId = user.Id }))
                    .Select(x => new Claim(x.ClaimType, x.ClaimValue))
                    .ToList();
        }

        public async Task RemoveClaimAsync(User user, Claim claim)
        {
            await Context.DB.ExecuteAsync("delete from UserClaims where UserId=@UserId and ClaimValue=@ClaimValue and ClaimType=@ClaimType", new { UserId = user.Id, ClaimValue = claim.Value, ClaimType = claim.Type }).ConfigureAwait(false);
        }
        #endregion

        #region IUserLockoutStore
        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        /// <summary>
        ///     Returns whether the user can be locked out.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserTwoFactorStore

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}