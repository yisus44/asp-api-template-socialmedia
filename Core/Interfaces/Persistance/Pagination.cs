using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Persistance
{
    public interface IPagination<T>
    {
        public int Page { get; set; }
        public int PerPage { get; set; }

        public Expression<Func<T, bool>>? Filter { get; set; }

        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; set; }

        public string IncludeProperties { get; set; }
    }
}
