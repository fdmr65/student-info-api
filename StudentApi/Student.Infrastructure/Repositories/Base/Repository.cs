using Microsoft.EntityFrameworkCore;
using StudentInfo.Application.Helper;
using StudentInfo.Domain.IRepositories.Base;
using StudentInfo.Domain.Models.Base;
using StudentInfo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly StudentContext _dbContext;

        public Repository(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            _dbContext.Set<T>().Remove(await _dbContext.Set<T>().FindAsync(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByActiveAsync()
        {
            return await _dbContext.Set<T>().Where(a=>a.IsActive==true).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetActivesByPageAsync(int skip , int take)
        {
            return await _dbContext.Set<T>().Where(a => a.IsActive == true).PageBy(skip,take).ToListAsync();
        }

       
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetActiveByPageAsync(Expression<Func<T, bool>> predicate,int skip,int take)
        {
            return await _dbContext.Set<T>().Where(predicate).Where(a=>a.IsActive == true).PageBy(skip,take).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

        }
    }
}
