﻿using System;
using Photography.Data.Contracts;
using Photography.Data.Entities;

namespace Photography.Data.Bolts
{
    internal class BaseUnitOfWork : IUnitOfWork, IDisposable
    {
        private BaseDbContext _dbContext;

        public BaseUnitOfWork(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = _dbContext;
            RepositoryProvider = repositoryProvider;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }

        public IRepository<UserEntity> Users
        {
            get { return GetStandardRepo<UserEntity>(); }
        }

        public IRepository<RoleEntity> Roles
        {
            get { return GetStandardRepo<RoleEntity>(); }
        }

        public IRepository<SessionEntity> Sessions
        {
            get { return GetStandardRepo<SessionEntity>(); }
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        protected void CreateDbContext()
        {
            _dbContext = new BaseDbContext();

            _dbContext.Configuration.ProxyCreationEnabled = false;
            _dbContext.Configuration.LazyLoadingEnabled = false;
            _dbContext.Configuration.ValidateOnSaveEnabled = false;
            _dbContext.Configuration.AutoDetectChangesEnabled = false;
        }

        private IRepository<T> GetStandardRepo<T>() where T : BaseEntity
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
