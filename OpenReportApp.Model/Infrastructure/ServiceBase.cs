using System;
using OpenReportApp.Model.DataContext;



namespace OpenReportApp.Model.Infrastructure
{
    public abstract class ServiceBase 
    {
        private DbContext dataContext;

        public ServiceBase(IDatabaseFactory DbFactory)
        {
            DatabaseFactory = DbFactory;
        }

        public ServiceBase()
        {
        }

        protected IDatabaseFactory DatabaseFactory { get; private set; }

        protected DbContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        } 
    }
}
