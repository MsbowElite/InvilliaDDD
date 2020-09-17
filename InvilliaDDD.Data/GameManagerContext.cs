using System;
using InvilliaDDD.GameManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InvilliaDDD.GameManager.Data
{
    public partial class GameManagerContext : DbContext
    {
        public GameManagerContext()
        {
        }

        public GameManagerContext(DbContextOptions<GameManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Game { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
