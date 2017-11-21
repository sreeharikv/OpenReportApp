using System.Collections.Generic;

namespace OpenReportApp.Core.Entities
{
    public interface IPagedList
    {
        int PageSize { get; }
        int TotalNumberOfItems { get; }
        int CurrentPageNumber { get; }
        int TotalNumberOfPages { get; }
    }

    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
    }
}