using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Application.Dtos
{
    public class PaginatedList<T> : List<T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    
        public PaginatedList(IEnumerable<T> source, int pageSize, int index = 1)
        {
            TotalCount = source.Count();

            PageIndex = index;
            PageSize = pageSize == 0 ? TotalCount : pageSize;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            this.AddRange(source.Skip((PageIndex - 1) * PageSize).Take(PageSize));
        }

        private PaginatedList(IEnumerable<T> source, int pagesize,int pageindex,int totalcount): base(source)
        {
            PageIndex = pageindex;
            PageSize = pagesize;
            TotalCount = totalcount;
            TotalPages = (int)Math.Ceiling(totalcount / (double)PageSize);
        }

        public static async Task<PaginatedList<T>> FromIQueryable(IQueryable<T> source, int pagesize,int index = 1)
        {
            int totalcount = await source.CountAsync();
            pagesize = pagesize == 0 ? totalcount : pagesize;
            int totalpage = (int)Math.Ceiling(totalcount / (double)pagesize);
            if(index > totalpage)
            {
                return new PaginatedList<T>(new List<T>(), pagesize, totalcount);
            }
            if(index ==1 && pagesize == totalcount)
            {

            }
            else
            {
                source = source.Skip((pagesize - 1) * pagesize).Take(pagesize);
            }
            List<T> sourceList = await source.ToListAsync();
            return new PaginatedList<T>(sourceList, pagesize, index,totalcount);
        }
    }
}
