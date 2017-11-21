using System;
using OpenReportApp.Core.Entities.Identity;

namespace OpenReportApp.Model.Entities.Identity
{
    public class UserClaim:IdentityUserClaim<int,int>
    {
         /// <summary>
        /// Default constructor 
        /// </summary>
        public UserClaim()
        {
        }
    }
}