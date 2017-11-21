using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace OpenReportApp.Model.DataContext
{
    public class DbContext : IDisposable
    {
        private ReportDatabase _db { get; set; }
        private readonly string cnStr = string.Empty;

        public ReportDatabase Current
        {
            get
            {
                if(_db == null)
                {
                    DbConnection cnn = new SqlConnection(cnStr);
                    cnn.Open();
                    _db = ReportDatabase.Init(cnn, 30);
                }
                return _db;
            }
        }

        public DbContext(string connString)
        {
            if (!string.IsNullOrEmpty(connString))
                cnStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString;
        }

        public void Dispose()
        {
            if(_db!=null)
            {
                _db.Dispose();
            }
        }
    }
}