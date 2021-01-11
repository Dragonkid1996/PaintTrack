using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PaintTrack
{
    public partial class PaintTrackerContext : DbContext
    {
        public PaintTrackerContext()
        {
        }

        public PaintTrackerContext(DbContextOptions<PaintTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Miniature> Miniatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PaintTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.GameLink).IsUnicode(false);

                entity.Property(e => e.GameMaximumMiniatures).HasDefaultValueSql("((0))");

                entity.Property(e => e.GameMiniaturesPainted).HasDefaultValueSql("((0))");

                entity.Property(e => e.GameName).IsUnicode(false);

                entity.Property(e => e.GamePublisher).IsUnicode(false);
            });

            modelBuilder.Entity<Miniature>(entity =>
            {
                entity.HasKey(e => e.MiniId)
                    .HasName("PK__Miniatur__482490FF88315C03");

                entity.Property(e => e.MiniId).HasColumnName("MiniID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.MiniName).IsUnicode(false);

                entity.Property(e => e.MiniPhoto).IsUnicode(false);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Miniatures)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Miniature__GameI__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
