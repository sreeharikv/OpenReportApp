using System;

namespace OpenReportApp.Core.Entities.Identity
{
    public class IdentityUserRole<TPermissionKey, TUserKey, TRoleKey>
    {
        public TPermissionKey Id { get; set; }

        public TUserKey UserId { get; set; }
        public TRoleKey RoleId { get; set; }

        public IdentityUserRole() { }
    }
}
