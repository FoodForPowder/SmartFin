using Microsoft.EntityFrameworkCore;
using SmartFin.Entities;

namespace SmartFin.Db
{

    public class SmartFinDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Goal> Goals { get; set; }

        public DbSet<Recomendation> Recomendations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SmartFin;Username=admin;Password=admin; IncludeErrorDetail = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(o => o.goal)
                .WithOne(od => od.user)
                .HasForeignKey<Goal>(o => o.userId)
                .IsRequired();

            modelBuilder.Entity<User>()
            .HasMany(e => e.Categorys)
            .WithOne(e => e.user)
            .HasForeignKey(e => e.userId)
            .IsRequired(true);

            modelBuilder.Entity<User>()
            .HasMany(e => e.Expenses)
            .WithOne(e => e.user)
            .HasForeignKey(e => e.userId)
            .IsRequired(true);

            modelBuilder.Entity<User>()
            .HasMany(e => e.Recomendations)
            .WithOne(e => e.user)
            .HasForeignKey(e => e.userId)
            .IsRequired(true);

        }
    }
}