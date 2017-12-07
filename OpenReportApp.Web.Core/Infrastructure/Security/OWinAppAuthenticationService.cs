using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;

namespace OpenReportApp.Web.Core.Infrastructure.Security
{
    public class OWinAppAuthenticationService :IAuthenticationService
    {
        private readonly HttpContextBase _context;
        private const string AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;

        public OWinAppAuthenticationService(HttpContextBase context)
        {
            _context = context;
        }

        public void SignIn(Model.Entities.Identity.User user, IList<string> roleNames)
        {
            IList<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.FullName)
            };

            foreach (string roleName in roleNames)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName));
            }

            ClaimsIdentity identity = new ClaimsIdentity(claims, AuthenticationType);

            IOwinContext context = _context.Request.GetOwinContext();
            IAuthenticationManager authenticationManager = context.Authentication;

            authenticationManager.SignIn(identity);
        }

        public void SignOut()
        {
            IOwinContext context = _context.Request.GetOwinContext();
            IAuthenticationManager authenticationManager = context.Authentication;

            authenticationManager.SignOut(AuthenticationType);
        }
    }
}
