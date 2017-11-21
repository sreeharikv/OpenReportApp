using System;
using System.Security.Claims;
using OpenReportApp.Core.Entities.Identity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace OpenReportApp.Model.Entities.Identity
{
    public class Role:IdentityRole<int>
    {
        public string Description { get; set; }

         /// <summary>
        /// Default constructor 
        /// </summary>
        public Role()
        {
        }
    }
}