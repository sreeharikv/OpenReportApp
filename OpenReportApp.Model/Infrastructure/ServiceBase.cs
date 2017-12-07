using System;
using OpenReportApp.Model.DataContext;



namespace OpenReportApp.Model.Infrastructure
{
    public abstract class ServiceBase 
    {
        private ReportDbContext dataContext;

        public ServiceBase(IDatabaseFactory DbFactory)
        {
            DatabaseFactory = DbFactory;
        }

        public ServiceBase()
        {
        }

        protected IDatabaseFactory DatabaseFactory { get; private set; }

        protected ReportDbContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Init()); }
        } 
    }
}
