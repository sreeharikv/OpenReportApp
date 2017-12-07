using Autofac;
using System.Web;
using System.Web.Mvc;
using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OpenReportApp.Model.Data.Identity;
using OpenReportApp.Model.Entities.Identity;
using OpenReportApp.Service.Identity;
using OpenReportApp.Model.DataContext;


namespace OpenReportApp.Web.Bootstrapper
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(c => new UserStore<User>(c.Resolve<ApplicationDbContext>())).As<IUserStore<User, int>>().InstancePerRequest();
            builder.RegisterType<UserStore<User>>().As<IUserStore<User,int>>().InstancePerRequest();
            builder.RegisterType<RoleStore<Role>>().As<IRoleStore<Role, int>>().InstancePerRequest();

            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();

            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();

            builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ApplicationName​")
            }); 
            
        }
    }
}
