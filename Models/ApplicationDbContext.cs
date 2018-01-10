using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace letskanban.Models {
    public class ApplicationDbContext : IdentityDbContext<User>
    {
       
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }       
        public DbSet<Story> Stories { get; set; }
        public DbSet<DocFile> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=karan184;Host=localhost;Port=5432;Database=letskanban;Pooling=true;");
        }
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
    }
}