using Ecom_API.DTO.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecom_API.DBHelpers
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>();
        }
    }
}