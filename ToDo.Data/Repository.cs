using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Interface;

namespace ToDo.Data
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {


        protected ApplicationDbContext _repositoryContext { get; set; }

        public Repository(ApplicationDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }


        public async Task<IEnumerable<T>> GetAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> dbQuery = _repositoryContext.Set<T>();

            if (includes != null)
                dbQuery = includes(dbQuery);



            return await dbQuery.AsNoTracking().ToListAsync();

        }

        public  async Task<T> FindAsync(Expression<Func<T, bool>> match, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> dbQuery = _repositoryContext.Set<T>();

            if (includes != null)
                dbQuery = includes(dbQuery);

            return await dbQuery.AsNoTracking().SingleOrDefaultAsync(match);
        }



        public async Task<int> CountAsync()
        {
            return await _repositoryContext.Set<T>().CountAsync();
        }


        public async Task<T> CreateAsync(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }

      
    }
}
