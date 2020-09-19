using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Shared
{
    public class PaginatedItemsViewModel<TDTO> where TDTO : class
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public long Count { get; set; }

        public List<TDTO> Data { get; set; }
    }
}
