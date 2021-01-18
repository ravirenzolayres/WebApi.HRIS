using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HrisApi.Data.DBase
{
    public class DBase<T> : IDBase<T> where T : class
    {
        private readonly DbContext db;
        public DBase(DbContext dbContext)
        {
            db = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            db.Set<T>().Add(entity);
            return await Task.FromResult(entity);
        }

        public async Task<T> Delete(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }

        public async Task<T> Edit(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }

        public async Task<T> Get(Func<T, bool> condition)
        {
           return await Task.FromResult(db.Set<T>().Where(condition).FirstOrDefault());
        }

        public async Task<List<T>> GetAll()
        {
            return await Task.FromResult(db.Set<T>().ToList());
        }

        public async Task<List<T>> GetAll(Func<T, bool> condition)
        {
           return await Task.FromResult(db.Set<T>().Where(condition).ToList());
        }

        public async Task Complete()
        {
           await db.SaveChangesAsync();
        }
    }
}
