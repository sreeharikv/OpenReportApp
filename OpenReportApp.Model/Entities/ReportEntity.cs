﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenReportApp.Core.Entities;

namespace OpenReportApp.Model.Entities
{
    public class ReportEntity : AuditableEntity<int> 
    {
        public string CMSEntityId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
    }
}