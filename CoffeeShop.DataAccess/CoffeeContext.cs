using CoffeeShop.BusinessEntity.Entities;
using CoffeeShop.BusinessEntity.Enums;
using Microsoft.EntityFrameworkCore;


namespace CoffeeShop.DataAccess
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> options)
           : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Coffee> Coffees { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BaseEntity>().Property(u => u.CreationDate).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<BaseEntity>().Property(u => u.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<Order>().Property(o => o.State).HasDefaultValue(OrderState.New);

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique();
        }
    }
}
