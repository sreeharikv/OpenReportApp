using System;
using System.Security.Claims;
using OpenReportApp.Core.Entities.Identity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace OpenReportApp.Model.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }

         /// <summary>
        /// Default constructor 
        /// </summary>
        public User()
        {
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("FullName", FullName));
            // Add custom user claims here
            return userIdentity;
        }
    }
}
