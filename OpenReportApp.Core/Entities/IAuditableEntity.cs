using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenReportApp.Core.Entities
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    } 
}
