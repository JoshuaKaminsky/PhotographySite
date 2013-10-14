using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Photography.Data.Entities;

namespace Photography.Data
{
    internal class BaseDbContext : DbContext
    {
        public BaseDbContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<SessionEntity> Sessions { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<AlbumEntity> Albums { get; set; }

        public DbSet<PhotoEntity> Photos { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        static BaseDbContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
