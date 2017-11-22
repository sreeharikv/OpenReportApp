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


namespace OpenReportApp.Web.Bootstrapper
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //user store
            builder.RegisterType<UserStore<User>>().As<IUserStore<User,int>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();

            //rolestore
            builder.RegisterType<RoleStore<Role>>().As<IRoleStore<Role, int>>().InstancePerRequest();
            builder.RegisterType<ApplicationRoleManager>().AsSelf();

            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();

            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();

            builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Application​")
            }); 
            
        }
    }
}
