using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using OpenReportApp.Model.Entities.Identity;

namespace OpenReportApp.Service.Identity
{
    public class ApplicationRoleManager : RoleManager<Role, int>
    {

        public ApplicationRoleManager(IRoleStore<Role, int> roleStore)
            : base(roleStore)
        {
        }
    }
}
