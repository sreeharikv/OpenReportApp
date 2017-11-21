using System.Security.Claims;
using System.Web.Mvc;
using OpenReportApp.Web.Core.Infrastructure.Security;

namespace OpenReportApp.Web.Core.Infrastructure
{
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {

        protected AppUserPrincipal CurrentUser
        {
            get
            {
                return SecurityData.CurrentUser;
            }
        }

        protected bool IsAuthenticated
        {
            get { return this.CurrentUser.Identity.IsAuthenticated; }
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}