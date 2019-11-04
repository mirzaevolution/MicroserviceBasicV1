using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FxStore.OrderHistories.Worker
{
    public partial class OrderHistoryRepoContext : DbContext
    {
        public OrderHistoryRepoContext()
        {
        }

        public OrderHistoryRepoContext(DbContextOptions<OrderHistoryRepoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderHistories> OrderHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrderHistoryRepo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<OrderHistories>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
