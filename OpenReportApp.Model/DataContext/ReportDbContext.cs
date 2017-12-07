using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace OpenReportApp.Model.DataContext
{
    public class ReportDbContext : IDisposable
    {
        private ReportDatabase _db;
        private DbConnection _connection;

        public ReportDatabase DB
        {
            get
            {
                if (_db == null)
                {
                    if (_connection.State != ConnectionState.Open)
                        _connection.Open();
                    _db = ReportDatabase.Init(_connection, 30);
                }
                return _db;
            }
        }

        public ReportDbContext()
            : this(System.Configuration.ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString)
        {

        }

        public ReportDbContext(string connString)
        {
            if (string.IsNullOrEmpty(connString))
            {
                connString = System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString;
            }
            else
            {
                connString = System.Configuration.ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString;
            }

            _connection = new SqlConnection(connString);
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}
