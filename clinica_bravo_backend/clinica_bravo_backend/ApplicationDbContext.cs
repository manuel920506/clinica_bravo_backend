using clinica_bravo_backend.Entities;
using Microsoft.EntityFrameworkCore; 

namespace clinica_bravo_backend {
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Topic>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<SubTopic>()
                .HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<SubTopic> SubTopics { get; set; } 
    }
}
