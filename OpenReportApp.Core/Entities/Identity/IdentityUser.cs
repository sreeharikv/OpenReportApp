using Microsoft.AspNet.Identity;
using System;

namespace OpenReportApp.Core.Entities.Identity
{
    public class IdentityUser<TUserKey> : IUser<TUserKey>
    {
        public TUserKey Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifyBy { get; set; }
    }
}
