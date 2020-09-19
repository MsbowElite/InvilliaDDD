using System;
using System.Linq;
using System.Threading.Tasks;
using InvilliaDDD.Core.Communication.Mediator;
using InvilliaDDD.Core.Data.Interfaces;
using InvilliaDDD.GameManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InvilliaDDD.GameManager.Data
{
    public partial class GameManagerContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public GameManagerContext(DbContextOptions<GameManagerContext> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameBorrowed> GameBorrowed { get; set; }

        public async Task<bool> Commit()
        {
            //MsbowElite
            //Domain event is Missing

            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<GameBorrowed>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.Property(e => e.GameId).ValueGeneratedNever();

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.GameBorrowed)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameBorrowed_Friend");

                entity.HasOne(d => d.Game)
                    .WithOne(p => p.GameBorrowed)
                    .HasForeignKey<GameBorrowed>(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameBorrowed_Game");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
