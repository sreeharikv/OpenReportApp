using System;
using OpenReportApp.Model.DataContext;



namespace OpenReportApp.Model.Infrastructure
{
    class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ApplicationDbContext dataContext;

        public ApplicationDbContext Get()
        {
            return dataContext ?? (dataContext = ApplicationDbContext.Create());
        }
    }
}
