using Microsoft.EntityFrameworkCore;
using MVVM_learn.Models.Entyties;

namespace MVVM_learn.Models.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Order> Order { get; set; }

        public ApplicationContext() : base()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOSOK\\GACHIBASE;Database=Trade1;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false;");
        }
    }
}
