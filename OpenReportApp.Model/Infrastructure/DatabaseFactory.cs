using System;
using OpenReportApp.Model.DataContext;



namespace OpenReportApp.Model.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ReportDbContext dataContext;

        public ReportDbContext Init()
        {
            return dataContext ?? (dataContext = new ReportDbContext());
        }
    }
}
