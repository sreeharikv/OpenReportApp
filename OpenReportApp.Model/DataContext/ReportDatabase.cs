using System;
using OpenReportApp.Model.Dapper;
using OpenReportApp.Model.Entities;
using OpenReportApp.Model.Entities.Identity;

namespace OpenReportApp.Model.DataContext
{
    public class ReportDatabase : Database<ReportDatabase>
    {
        public Table<User> Users { get; private set; }
        public Table<Role> Roles { get; private set; }
        public Table<UserRole> UserRoles { get; private set; }
        public Table<UserClaim> UserClaims { get; private set; }

        public Table<ReportEntity> ReportEntities { get; private set; }
    }
}