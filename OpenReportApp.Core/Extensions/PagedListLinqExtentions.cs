using System.Linq;
using System.Collections.Generic;
using OpenReportApp.Core.Entities;

namespace OpenReportApp.Core.Extensions
{
    public static class PagedListLinqExtentions
    {
        #region IQueryable<T> extensions

        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int currentPageNumber, int pageSize, int? totalNumberOfItems = null)
        {
            return new PagedList<T>(source, currentPageNumber, pageSize, totalNumberOfItems);
        }

        #endregion

        #region IEnumerable<T> extensions

        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int currentPageNumber, int pageSize, int? totalNumberOfItems = null)
        {
            return new PagedList<T>(source, currentPageNumber, pageSize, totalNumberOfItems);
        }

        #endregion
    }
}