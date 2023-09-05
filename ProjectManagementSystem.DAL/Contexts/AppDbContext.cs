using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Entities;

namespace ProjectManagementSystem.DAL.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Member> Members { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Domain.Entities.Task> Tasks { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>()
            .HasMany(x => x.Tasks)
            .WithOne(x => x.Member)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Team>()
            .HasMany(x => x.Members)
            .WithOne(x => x.Team)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Team>()
            .HasMany(x => x.Projects)
            .WithOne(x => x.Team)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Project>()
            .HasMany(x => x.Tasks)
            .WithOne(x => x.Project)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
