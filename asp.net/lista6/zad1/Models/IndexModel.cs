using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zad1.DataLayer;

namespace zad1.Models
{
    public class PagedEnumerable<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
    }

    public class IndexModel
    {
        public PagedEnumerable<PERSON> Persons { get; set; }
    }
}