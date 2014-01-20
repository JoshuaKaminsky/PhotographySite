using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Photography.Data.Entities;

namespace Photography.Data.Contracts
{
    internal interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAllQueryable();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);

        T Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);

        T GetById(int id);

        T Add(T entity);

        T Update(T entity);

        bool Delete(T entity);

        bool Delete(int id);
    }
}
