namespace Command_Saver_data
{
    using Command_Saver_data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CommandSaverDbContext : DbContext
    {
        public CommandSaverDbContext()
        {

        }

        public CommandSaverDbContext(DbContextOptions<CommandSaverDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Command> Commands { get; set; }

        public virtual DbSet<CommandPlatform> CommandPlatforms { get; set; }

        public virtual DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CommandPlatform>(cp =>
            {
                cp.HasKey(cp => new { cp.CommandId, cp.PlatformId });

                cp.HasOne(cp => cp.Command)
                .WithMany(p => p.Platforms)
                .HasForeignKey(p => p.CommandId)
                .OnDelete(DeleteBehavior.Restrict);

                cp.HasOne(cp => cp.Platform)
                .WithMany(p => p.Commands)
                .HasForeignKey(p => p.PlatformId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}