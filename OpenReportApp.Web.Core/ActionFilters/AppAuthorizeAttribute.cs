using System;
using System.Web;
using System.Web.Mvc;
using OpenReportApp.Web.Core.Infrastructure.Security;

namespace OpenReportApp.Web.Core.ActionFilters
{
    public class AppAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
			if (!SecurityData.IsAuthenticated) {
				return false;
			}

			if (SecurityData.IsAuthenticated) {
				return true;
			}

			return false;
		}

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            bool skipAuth = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
								|| filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            if (skipAuth)
            {
                return;
            }
            else
            {
                if (!AuthorizeCore(filterContext.HttpContext))
                {
                    HandleUnauthorizedRequest(filterContext);
                    return;
                }
            }
        }

        protected virtual void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.Path.ToLowerInvariant() != SecurityData.LoginPath.ToLowerInvariant())
            {
                filterContext.Result = new RedirectResult(String.Format("{0}?returnUrl={1}", SecurityData.LoginPath, HttpUtility.UrlEncode(filterContext.HttpContext.Request.Path)));
            }
            else
            {
                filterContext.Result = new RedirectResult(SecurityData.LoginPath);
            }

            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult(SecurityData.NotAuthorizedURL);
            }

            return;
        }
    }
}