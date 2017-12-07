using System.Collections.Generic;

namespace OpenReportApp.Web.Core.Infrastructure.Security
{
    public interface IAuthenticationService
    {
        void SignIn(Model.Entities.Identity.User user, IList<string> roleNames);
        void SignOut();
    }
}
