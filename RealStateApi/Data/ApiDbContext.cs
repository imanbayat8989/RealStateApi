using Microsoft.EntityFrameworkCore;
using RealStateApi.Models;

namespace RealStateApi.Data
{
    public class ApiDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RealState_Db");
        }
    }
}
