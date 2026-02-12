using Microsoft.EntityFrameworkCore;

namespace IT_STEP
{
    public class MoviesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                @"Server=ALEKSEY\IT_STEP;
                  Database=MoviesDb;
                  Trusted_Connection=True;
                  TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<User>(b =>
            {
                b.ToTable(t => t.HasCheckConstraint("CK_NotEmptyUserName", "[UserName] <> ''"));
                b.ToTable(t => t.HasCheckConstraint("CK_Email", "[Email] LIKE '%@%.com'"));
                
            });

            modelBuilder.Entity<Movie>(b =>
            {
                b.ToTable(t => t.HasCheckConstraint("CK_TitleNotEmpty", "LEN([Title]) > 0"));
                b.ToTable(t => t.HasCheckConstraint("CK_YearMoreZero", "[Year] > 0"));
            });
        }
    }
}
