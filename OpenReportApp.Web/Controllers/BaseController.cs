using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Web.Routing;
using OpenReportApp.Common;
using OpenReportApp.Web.Core.ActionFilters;
using OpenReportApp.Web.Core.Infrastructure.Security;



namespace OpenReportApp.Web.Controllers
{
    [AppAuthorize]
    public class BaseController : Controller
    {
        public AppUserPrincipal CurrentUser
        {
            get
            {
                return SecurityData.CurrentUser;
            }
        }

        public bool IsCurrentUserAdministrator
        {
            get { return this.CurrentUser.UserType == AppUserType.Administrator; }
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            //var result = filterContext.Result as ViewResult;
            //if (result != null)
            //{
            //    if (filterContext.Controller.ViewData.Model as AppViewModel == null)
            //        filterContext.Controller.ViewData.Model = new AppViewModel();
            //}

        }

    }
}