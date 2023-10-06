using Core.Interfaces.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO
{
    public class PaginationDto<T> : IPagination<T>
    {
        public int Page { get; set; } = 1;
        public int PerPage { get ; set ; } = 10;
        public Expression<Func<T, bool>>? Filter { get ; set ; } = null;
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get ; set ; } = null;
        public string IncludeProperties { get ; set ; } = "";
    }
}
