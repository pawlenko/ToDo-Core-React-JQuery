using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Data.Interface
{
    public interface IRepository<T>
    {

        Task<IEnumerable<T>> GetAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<T> FindAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<int> CountAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();

    }
}
