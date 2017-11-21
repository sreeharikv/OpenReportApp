using Owin;

namespace OpenReportApp.Web.Bootstrapper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
