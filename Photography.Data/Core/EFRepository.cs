using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Photography.Data.Contracts;
using Photography.Data.Entities;
using System.Data;

namespace Photography.Data.Core
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

        public virtual IQueryable<T> GetAllQueryable()
        {
            return DbSet;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            return GetItems(filter, (includes != null) ? includes.Select(GetPropertyName).ToList() : null);
        }

        public T Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            return GetItems(filter,  (includes != null) ? includes.Select(GetPropertyName).ToList() : null).SingleOrDefault();
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
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Modified;
            }
            else
            {
                var set = DbContext.Set<T>();
                var attachedEntity = set.Local.SingleOrDefault(local => local.Id == entity.Id); 

                if (attachedEntity != null)
                {
                    DbContext.Entry(attachedEntity).CurrentValues.SetValues(entity);
                }
            }

            return entity;
        }

        public virtual bool Delete(int id)
        {
            var entity = GetById(id);
            return entity == null || Delete(entity);
        }

        public virtual bool Delete(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
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

        private IQueryable<T> GetItems(Expression<Func<T, bool>> filter, ICollection<string> includes = null)
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

        private static string GetPropertyName(Expression<Func<T, object>> propertyExpression)
        {
            var expression = propertyExpression.Body as MemberExpression;

            if (expression == null)
            {
                throw new DataException("Could not access property with expression " + propertyExpression.ToString());
            }

            return expression.Member.Name;
        }

        private static IEnumerable<Type> GetNavigationProperties<TEntity>()
        {
           return typeof (TEntity).GetProperties()
                .Where(type => type.PropertyType == typeof(ICollection))
                .Select(type => type.PropertyType)
                .ToList();
        }
    }
}
