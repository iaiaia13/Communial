using Microsoft.EntityFrameworkCore;
using NetCoreData.Models;
using System.Reflection;

namespace NetCoreData
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> User { get; set; }

        //public DbSet<Food> Food { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}