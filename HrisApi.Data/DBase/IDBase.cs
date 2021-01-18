using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HrisApi.Data.DBase
{
    public interface IDBase<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Edit(T entity);
        Task<T> Delete(T entity);
        Task<T> Get(Func<T, bool> condition);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Func<T,bool> condition);
        Task Complete();
    }
}
