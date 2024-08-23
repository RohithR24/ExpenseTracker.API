using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Data
{
    public class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data.Models.User>()
                .ToTable("Users")
                .HasKey(u => u.Id);
            
            modelBuilder.Entity<Data.Models.User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

        }
    }
}
