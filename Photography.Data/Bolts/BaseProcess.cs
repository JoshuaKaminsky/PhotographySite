using System.Collections.Generic;
using Photography.Core.Models;
using Photography.Data.Contracts;
using Photography.Data.Entities;

namespace Photography.Data.Bolts
{
    internal class BaseProcess
    {
        internal readonly IUnitOfWork UnitOfWork;

        public BaseProcess(IUnitOfWork unitOfWork)
         {
             UnitOfWork = unitOfWork;
         }

        internal class ModelComparer<TModel> : IEqualityComparer<TModel> where TModel : BaseModel
        {
            public bool Equals(TModel x, TModel y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode(TModel obj)
            {
                return obj.GetHashCode();
            }
        }

        internal class EntityComparer<TEntity> : IEqualityComparer<TEntity> where TEntity : BaseEntity
        {
            public bool Equals(TEntity x, TEntity y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode(TEntity obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}