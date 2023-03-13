using Microsoft.EntityFrameworkCore;
using ModsenTask.Data.Data.Configuration;
using ModsenTask.Data.Entities;
using System.Reflection;

namespace ModsenTask.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            Database.Migrate();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ModsenTaskDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            //builder.Entity<User>(entity => entity.ToTable(name: "Users"));
            //builder.Entity<Book>(entity => entity.ToTable(name: "Books"));


            //builder.ApplyConfiguration(new BookConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
