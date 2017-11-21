using System;
using OpenReportApp.Core.Entities.Identity;

namespace OpenReportApp.Model.Entities.Identity
{
    public class UserRole:IdentityUserRole<int, int,int>
    {
         /// <summary>
        /// Default constructor 
        /// </summary>
        public UserRole()
        {
        }
    }
}