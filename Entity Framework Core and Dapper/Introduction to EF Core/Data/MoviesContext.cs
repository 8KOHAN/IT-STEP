using Microsoft.EntityFrameworkCore;

namespace IT_STEP
{
    public class MoviesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                @"Server=ALEKSEY\IT_STEP;
                  Database=MoviesDb;
                  Trusted_Connection=True;
                  TrustServerCertificate=True;");
        }
    }
}
