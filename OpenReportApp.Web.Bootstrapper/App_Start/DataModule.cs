using Autofac;
using OpenReportApp.Model.DataContext;
using OpenReportApp.Model.Infrastructure;

namespace OpenReportApp.Web.Bootstrapper
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReportDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();
        }
    }
}
