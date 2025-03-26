using LoginSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        // Adicione outras propriedades DbSet<T> para suas entidades...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações do modelo...
            base.OnModelCreating(modelBuilder);
        }
    }
}