using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenReportApp.Model.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionName)
            : base(connectionName)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(System.Configuration.ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString);
        }
    }
}
