
using Photography.Data.Entities;

namespace Photography.Data.Contracts
{
    internal interface IUnitOfWork
    {
        void Commit();

        void Rollback();

        IRepository<UserEntity> Users { get; }

        IRepository<RoleEntity> Roles { get; }

        IRepository<SessionEntity> Sessions { get; }

        IRepository<PhotoEntity> Photos { get; }

        IRepository<TagEntity> Tags { get; } 
    }
}
