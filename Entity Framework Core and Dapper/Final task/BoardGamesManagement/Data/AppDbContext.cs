using BoardGamesManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesManagement.Data;

public class AppDbContext : DbContext
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Member> Members => Set<Member>();
    public DbSet<Session> Sessions => Set<Session>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=ALEKSEY\\IT_STEP;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(builder =>
        {
            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.MinPlayers)
                .IsRequired();

            builder.Property(g => g.MaxPlayers)
                .IsRequired();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_Game_MinPlayers", "[MinPlayers] > 0");
                t.HasCheckConstraint("CK_Game_MaxPlayers", "[MaxPlayers] > 0");
            });

            builder.HasMany(g => g.Sessions)
                .WithOne(s => s.Game)
                .HasForeignKey(s => s.GameId);
        });

        modelBuilder.Entity<Member>(builder =>
        {
            builder.Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.JoinDate)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.HasMany(m => m.Sessions)
                .WithOne(s => s.Member)
                .HasForeignKey(s => s.MemberId);
        });

        modelBuilder.Entity<Session>(builder =>
        {
            builder.Property(s => s.Date)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(s => s.DurationMinutes)
                .IsRequired();
        });
    }
}
