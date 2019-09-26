using Microsoft.EntityFrameworkCore;
using SchoolRegister.Core.Domain;

namespace SchoolRegister.Infrastructure.EF
{
    public class SchoolRegisterContext : DbContext
    {
        private readonly SqlSettings _settings;
        public DbSet<User> Users { get; set; }

        public SchoolRegisterContext(DbContextOptions<SchoolRegisterContext> options, SqlSettings settings) : base(options)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_settings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase("Database");

                return;    
            }
            optionsBuilder.UseSqlServer(_settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var itemBuilder = modelBuilder.Entity<User>();
            itemBuilder.HasKey(x => x.Id); 
        }
    } 
}