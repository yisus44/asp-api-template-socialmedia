using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Persistance
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAsync(IPagination<T> pagination);
        Task<int> Count(IPagination<T> pagination);
        Task<T?> GetOneByIdAsync(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
       
    }
}
