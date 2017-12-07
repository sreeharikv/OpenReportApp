using OpenReportApp.Web.Core.ActionFilters;
using System.Web.Mvc;


namespace OpenReportApp.Web.Controllers
{
    [AppAuthorize]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}