using OpenReportApp.Core.Entities;
using System;


namespace OpenReportApp.Core.Services
{
    public interface IEntityService<T> : IService where T : BaseEntity
    {

    }
}
