using Core.Entities;
using Core.Interfaces.Persistance;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistance
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _databaseContext;
        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async void Delete(int id)
        {
            var entity = await GetOneByIdAsync(id);
            _databaseContext.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAsync(IPagination<T> pagination)
        {
            IQueryable<T> query = BuildQuery(pagination);
            if (pagination.OrderBy != null)
            {
                return await pagination.OrderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<int> Count(IPagination<T> pagination)
        {
            IQueryable<T> query = BuildQuery(pagination, false);
            return await query.CountAsync();
        }

        public IQueryable<T> BuildQuery(IPagination<T> pagination, bool includePagination=true)
        {
            IQueryable<T> query = _databaseContext.Set<T>();

            if (pagination.Filter != null)
            {
                query = query.Where(pagination.Filter);
            }

            foreach (var includeProperty in pagination.IncludeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (includePagination)
            {
                query = query.Skip((pagination.Page - 1) * pagination.PerPage);
                query = query.Take(pagination.PerPage);
            }
            return query;
        }

        public async Task<T?> GetOneByIdAsync(int id)
        {
            return await _databaseContext.Set<T>().FindAsync(id);
        }

        public void Insert(T entity)
        {
            _databaseContext.Set<T>().Add(entity);
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _databaseContext.Set<T>().Update(entity);
        }
    }
}
