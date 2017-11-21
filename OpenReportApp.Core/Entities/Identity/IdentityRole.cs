using System;
using Microsoft.AspNet.Identity;

namespace OpenReportApp.Core.Entities.Identity
{
    public class IdentityRole<TRoleKey> : IRole<TRoleKey>
    {
        public TRoleKey Id { get; set; }

        public string Name { get; set; }

        public IdentityRole() { }
    }
}
