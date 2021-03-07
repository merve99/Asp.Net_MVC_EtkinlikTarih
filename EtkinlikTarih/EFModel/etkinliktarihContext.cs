using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EtkinlikTarih.EFModel
{
    public partial class etkinliktarihContext : DbContext
    {
        public etkinliktarihContext()
        {
        }

        public etkinliktarihContext(DbContextOptions<etkinliktarihContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Etkinlik> Etkinlik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-KIDPJQS4\\SQLEXPRESS;Database=etkinliktarih;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etkinlik>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Baslangic)
                    .HasColumnName("baslangic")
                    .HasColumnType("datetime");

                entity.Property(e => e.Bitis)
                    .HasColumnName("bitis")
                    .HasColumnType("datetime");

                entity.Property(e => e.Konu)
                    .HasColumnName("konu")
                    .HasMaxLength(100);

                entity.Property(e => e.Renk)
                    .HasColumnName("renk")
                    .HasMaxLength(10);

                entity.Property(e => e.Tanim)
                    .HasColumnName("tanim")
                    .HasMaxLength(300);

                entity.Property(e => e.Tumgun).HasColumnName("tumgun");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
