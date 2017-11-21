using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNet.Identity;
using OpenReportApp.Model.Entities.Identity;
using OpenReportApp.Model.DataContext;


namespace OpenReportApp.Model.Data.Identity
{
    public class RoleStore<TRole> : 
                    IQueryableRoleStore<Role, int> 
                    where TRole:Role
    {
        #region private
        private DbContext Context;
        #endregion

        /// <summary>
        /// Constructor that takes a dbmanager as argument 
        /// </summary>
        /// <param name="database"></param>
        public RoleStore(DbContext dbcontext)
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

        #region IQueryableRoleStore

        private IQueryable<Role> _roles;
        public IQueryable<Role> Roles
        {
            get
            {
                return (_roles = Context.Current.Query<Role>(@"select * from Roles").AsQueryable());
            }
        }

        public async Task CreateAsync(Role role)
        {
            await Context.Current.Roles.InsertAsync(role);
        }

        public async Task DeleteAsync(Role role)
        {
            await Context.Current.Roles.DeleteAsync(role.Id);
        }

        public async Task<Role> FindByIdAsync(int roleId)
        {
            return (await Context.Current.QueryAsync<Role>(@"select * from Roles where Id=@Id", new { Id = roleId })).SingleOrDefault();
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            return (await Context.Current.QueryAsync<Role>(@"select * from Roles where Name=@Name", new { Name = roleName })).SingleOrDefault();
        }

        public async Task UpdateAsync(Role role)
        {
            await Context.Current.Roles.UpdateAsync(role.Id, role);
        }
        #endregion
    }
}