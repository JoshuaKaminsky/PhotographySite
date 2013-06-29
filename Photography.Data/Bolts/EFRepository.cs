using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Photography.Data.Contracts;
using Photography.Data.Entities;

namespace Photography.Data.Bolts
{
    internal class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        public EFRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");

            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public System.Collections.Generic.IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, System.Collections.Generic.List<string> includes = null)
        {
            return GetItems(filter, includes);
        }

        public T Get(Expression<Func<T, bool>> filter, System.Collections.Generic.List<string> includes = null)
        {
            return GetItems(filter, includes).SingleOrDefault();
        }

        public virtual T GetById(int id)
        {
            return DbSet.FirstOrDefault(item => item.Id == id);
        }

        public virtual T Add(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }

            return entity;
        }

        public virtual T Update(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            dbEntityEntry.State = EntityState.Modified;

            return entity;
        }

        public virtual bool Delete(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }

            return true;
        }

        public virtual bool Delete(int id)
        {
            var entity = GetById(id);
            return entity == null || Delete(entity);
        }

        public T Get(Func<T, bool> filter)
        {
            return DbSet.SingleOrDefault(filter);
        }

        private IQueryable<T> GetItems(Expression<Func<T, bool>> filter, System.Collections.Generic.List<string> includes = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null && includes.Count > 0)
            {
                query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return query;
        }
    }
}
