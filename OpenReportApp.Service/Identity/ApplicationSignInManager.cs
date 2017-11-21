using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OpenReportApp.Model.Entities.Identity;

namespace OpenReportApp.Service.Identity
{
    public class ApplicationSignInManager : SignInManager<User, int>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }
    }
}
