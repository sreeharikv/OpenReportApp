using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenReportApp.Core.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    } 
}
