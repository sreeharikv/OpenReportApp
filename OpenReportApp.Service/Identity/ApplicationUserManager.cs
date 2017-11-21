using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using OpenReportApp.Model.Entities.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace OpenReportApp.Service.Identity
{
    public class ApplicationUserManager : UserManager<User, int>
    {
        public ApplicationUserManager(IUserStore<User, int> store, IDataProtectionProvider dataProtectionProvider)
            : base(store)
        {
            UserValidator = new UserValidator<User, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            
            // Configure validation logic for passwords
            PasswordValidator = new PasswordValidator
            {
                //RequiredLength = 6,
                //RequireNonLetterOrDigit = true,
                //RequireDigit = true,
                //RequireLowercase = true,
                //RequireUppercase = true,
            };

            UserTokenProvider = new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("ASP.NET Identity"));
        }
    }
}
