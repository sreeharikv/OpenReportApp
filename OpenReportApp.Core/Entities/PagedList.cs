using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenReportApp.Core.Entities
{
    public class PagedList<T> :  List<T>, IPagedList<T>
    {
        public int PageSize { get; private set; }
        public int TotalNumberOfItems { get; private set; }
        public int CurrentPageNumber { get; private set; }
        public int TotalNumberOfPages { get; private set; }

        public PagedList(IEnumerable<T> source, int currentPageNumber, int pageSize, int? totalNumberOfItems = null)
            : this(source.AsQueryable(), currentPageNumber, pageSize, totalNumberOfItems)
        {
        }

        public PagedList(IQueryable<T> source, int currentPageNumber, int pageSize, int? totalNumberOfItems = null)
        {
            if (source == null)
                source = new List<T>().AsQueryable();
            AddRange(source);

            if (currentPageNumber < 1)
                currentPageNumber = 1;

            var realTotalCount = source.Count();
            PageSize = pageSize;
            CurrentPageNumber = currentPageNumber;
            TotalNumberOfItems = totalNumberOfItems.HasValue ? totalNumberOfItems.Value : realTotalCount;
            var totalNumberOfPages = totalNumberOfItems == 0 ? 1 : (totalNumberOfItems / pageSize + (totalNumberOfItems % pageSize > 0 ? 1 : 0));
        }
    }
}