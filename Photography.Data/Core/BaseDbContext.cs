using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Photography.Data.Entities;

namespace Photography.Data.Core
{
    internal class BaseDbContext : DbContext
    {
        public BaseDbContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<AlbumEntity> Albums { get; set; }

        public DbSet<PhotoEntity> Photos { get; set; }

        public DbSet<ResetPasswordRequestEntity> ResetPasswordRequests { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<SessionEntity> Sessions { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        static BaseDbContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumEntity>()
                .HasMany(album => album.Photos)
                .WithMany(photo => photo.Albums)
                .Map(map =>
                    {
                        map.MapLeftKey("AlbumId");
                        map.MapRightKey("PhotoId");
                        map.ToTable("PhotoAlbum");
                    });

            modelBuilder.Entity<AlbumEntity>()
                .HasMany(album => album.Tags)
                .WithMany(tag => tag.Albums)
                .Map(map =>
                {
                    map.MapLeftKey("AlbumId");
                    map.MapRightKey("TagId");
                    map.ToTable("AlbumTag");
                });

            modelBuilder.Entity<PhotoEntity>()
                .HasMany(photo => photo.Tags)
                .WithMany(tag => tag.Photos)
                .Map(map =>
                {
                    map.MapLeftKey("PhotoId");
                    map.MapRightKey("TagId");
                    map.ToTable("PhotoTag");
                });

            modelBuilder.Entity<UserEntity>()
                .HasMany(user => user.Albums)
                .WithMany(album => album.Users)
                .Map(map =>
                {
                    map.MapLeftKey("UserId");
                    map.MapRightKey("AlbumId");
                    map.ToTable("UserAlbum");
                });

            modelBuilder.Entity<UserEntity>()
                .HasMany(user => user.Roles)
                .WithMany(role => role.Users)
                .Map(map =>
                    {
                        map.MapLeftKey("UserId");
                        map.MapRightKey("RoleId");
                        map.ToTable("UserRole");
                    });

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
