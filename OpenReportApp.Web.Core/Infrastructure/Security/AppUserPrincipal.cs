using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Globalization;
using OpenReportApp.Common;

namespace OpenReportApp.Web.Core.Infrastructure.Security
{
    public class AppUserPrincipal : ClaimsPrincipal
    {
        public AppUserPrincipal(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        public int Id
        {
            get { return FindFirstValue<int>(ClaimTypes.NameIdentifier); }
        }

        public string UserName
        {
            get { return FindFirstValue<string>(ClaimsIdentity.DefaultNameClaimType); }
        }

        public string Email
        {
            get { return FindFirstValue<string>(ClaimTypes.Email); }
        }

        public string FullName
        {
            get { return this.FindFirstValue<string>("FullName"); }
        }

        public IEnumerable<string> Roles
        {
            get { return FindValues<string>(ClaimTypes.Role); }
        }

        public AppUserType UserType
        {
            get { return GetUserType(); }
        }

        AppUserType GetUserType()
        {
            AppUserType result = AppUserType.User;
            if(this.Identity.IsAuthenticated)
            {
                if (base.IsInRole(AppUserType.Administrator.ToString()))
                {
                    result = AppUserType.Administrator;
                }
            }
            return result;
        }

        T FindFirstValue<T>(string type)
        {
            return Claims
                .Where(p => p.Type == type)
                .Select(p => (T)Convert.ChangeType(p.Value, typeof(T), CultureInfo.InvariantCulture))
                .FirstOrDefault();
        }

        IEnumerable<T> FindValues<T>(string type)
        {
            return Claims
                .Where(p => p.Type == type)
                .Select(p => (T)Convert.ChangeType(p.Value, typeof(T), CultureInfo.InvariantCulture))
                .ToList();
        }

        ////In my controller:
        ////using XXX.CodeHelpers.Extended;
        ////var claimAddress = User.GetAddress();

        ////In my razor:
        ////@using DinexWebSeller.CodeHelpers.Extended;
        ////@User.GetFullName()
    }
}