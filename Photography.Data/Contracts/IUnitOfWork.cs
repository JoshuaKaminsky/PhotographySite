
using Photography.Data.Entities;

namespace Photography.Data.Contracts
{
    internal interface IUnitOfWork
    {
        void Commit();

        void Rollback();

        IRepository<AlbumEntity> Albums { get; }

        IRepository<CategoryEntity> Categories { get; }

        IRepository<PhotoEntity> Photos { get; }
        
        IRepository<ResetPasswordRequestEntity> ResetPasswordRequests { get; }

        IRepository<RoleEntity> Roles { get; }

        IRepository<SessionEntity> Sessions { get; }

        IRepository<TagEntity> Tags { get; }

        IRepository<UserEntity> Users { get; }
    }
}
