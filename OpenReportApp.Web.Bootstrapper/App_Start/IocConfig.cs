using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using OpenReportApp.Web.Bootstrapper;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IocConfig), "RegisterDependencies")]
namespace OpenReportApp.Web.Bootstrapper
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // REGISTER DEPENDENCIES
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new IdentityModule());

            // register mvc controllers

            // register webapi controller


            var container = builder.Build();

            // replace mvc dependancy resolver with autofac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // replace webapi dependancy resolver with autofac
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
