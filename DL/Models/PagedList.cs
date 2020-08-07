using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.Models
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalCount { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int itemsPerPage)
        {
            TotalCount = count;
            ItemsPerPage = itemsPerPage;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)itemsPerPage);
            this.AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int pageNumber, int itemsPerPage)
        {
            var count = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToListAsync();

            return new PagedList<T>(items, count, pageNumber, itemsPerPage);
        }
    }
}