using System.Web.Mvc;
using OpenReportApp.Web.Core.ActionFilters;
using OpenReportApp.Service.Identity;
using Microsoft.Owin.Security;



namespace OpenReportApp.Web.Controllers
{
    [AppAuthorize]
    public class AccountController : BaseController
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private IAuthenticationManager  _authenticationManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IAuthenticationManager authenticationManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}