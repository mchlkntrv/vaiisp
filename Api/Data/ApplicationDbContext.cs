namespace Api.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Mineral> Minerals { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionItem> CollectionItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Mineral>().ToTable("minerals");
            modelBuilder.Entity<Collection>().ToTable("collections");
            modelBuilder.Entity<CollectionItem>().ToTable("collection_items");

            modelBuilder.Entity<CollectionItem>()
                .HasKey(ci => ci.Id);

            modelBuilder.Entity<CollectionItem>()
                .HasOne<Collection>()
                .WithMany()
                .HasForeignKey(ci => ci.CollectionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CollectionItem>()
                .HasOne<Mineral>()
                .WithMany()
                .HasForeignKey(ci => ci.MineralId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Collection>()
              .HasOne(c => c.Owner)
              .WithMany(u => u.Collections)
              .HasForeignKey(c => c.OwnerId)
              .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
