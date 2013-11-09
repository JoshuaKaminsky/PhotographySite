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
            modelBuilder.Entity<AlbumEntity>()
                .HasMany(album => album.Photos)
                .WithMany()
                .Map(map =>
                    {
                        map.MapLeftKey("PhotoId");
                        map.MapRightKey("AlbumId");
                        map.ToTable("PhotoAlbum");
                    });

            modelBuilder.Entity<AlbumEntity>()
                .HasMany(album => album.Tags)
                .WithMany()
                .Map(map =>
                {
                    map.MapLeftKey("AlbumId");
                    map.MapRightKey("TagId");
                    map.ToTable("AlbumTag");
                });

            modelBuilder.Entity<PhotoEntity>()
                .HasMany(photo => photo.Tags)
                .WithMany()
                .Map(map =>
                {
                    map.MapLeftKey("PhotoId");
                    map.MapRightKey("TagId");
                    map.ToTable("PhotoTag");
                });

            modelBuilder.Entity<UserEntity>()
                .HasMany(user => user.Albums)
                .WithMany()
                .Map(map =>
                {
                    map.MapLeftKey("UserId");
                    map.MapRightKey("AlbumId");
                    map.ToTable("UserAlbum");
                });

            modelBuilder.Entity<UserEntity>()
                .HasMany(user => user.Roles)
                .WithMany()
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
