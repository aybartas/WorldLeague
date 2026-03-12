using Microsoft.EntityFrameworkCore;
using WorldLeague.API.Entities;

namespace WorldLeague.API.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupTeam> GroupTeams { get; set; }
        public DbSet<Draw> Draws { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).IsRequired();
                entity.Property(t => t.Country).IsRequired();
            });

            modelBuilder.Entity<Draw>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.DrawerFirstName).IsRequired();
                entity.Property(d => d.DrawerLastName).IsRequired();
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.Property(g => g.GroupName).IsRequired();

                entity.HasOne(g => g.Draw)
                    .WithMany(d => d.Groups)
                    .HasForeignKey(g => g.DrawId);
            });

            modelBuilder.Entity<GroupTeam>(entity =>
            {
                entity.HasKey(gt => gt.Id);

                entity.HasOne(gt => gt.Team)
                    .WithMany(t => t.GroupTeams)
                    .HasForeignKey(gt => gt.TeamId);

                entity.HasOne(gt => gt.Group)
                    .WithMany(g => g.GroupTeams)
                    .HasForeignKey(gt => gt.GroupId);
            });
        }
    }
}
