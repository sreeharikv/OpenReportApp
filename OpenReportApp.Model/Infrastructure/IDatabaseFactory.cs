using System;
using OpenReportApp.Model;
using OpenReportApp.Model.DataContext;


namespace OpenReportApp.Model.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ReportDbContext Init();
    }
}
