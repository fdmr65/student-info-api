using StudentInfo.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Domain.IRepositories.Base
{
    public interface IRepository<T>  where T : BaseEntity
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllByActiveAsync();
        Task<IEnumerable<T>> GetActivesByPageAsync(int skip, int take);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetActiveByPageAsync(Expression<Func<T, bool>> predicate, int skip, int take);
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
