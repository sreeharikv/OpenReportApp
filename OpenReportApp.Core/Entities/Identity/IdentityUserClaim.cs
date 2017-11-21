using System;

namespace OpenReportApp.Core.Entities.Identity
{
    public class IdentityUserClaim<TUserKey, TClaimKey>
    {
        public TClaimKey Id { get; set; }

        public TUserKey UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
