using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UdlaansAPI.Entities
{
    public partial class udlaansregistreringContext : DbContext
    {
        public udlaansregistreringContext()
        {
        }

        public udlaansregistreringContext(DbContextOptions<udlaansregistreringContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<ComputerStatus> ComputerStatuses { get; set; }
        public virtual DbSet<Keyboard> Keyboards { get; set; }
        public virtual DbSet<Mouse> Mice { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Computer>(entity =>
            {
                entity.ToTable("Computer");

                entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Computer_Name");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Computers)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Computer__Status__5535A963");
            });

            modelBuilder.Entity<ComputerStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("ComputerStatus");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Keyboard>(entity =>
            {
                entity.ToTable("Keyboard");

                entity.Property(e => e.KeyboardId).HasColumnName("Keyboard_ID");

                entity.Property(e => e.KeyboardType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Keyboard_Type");
            });

            modelBuilder.Entity<Mouse>(entity =>
            {
                entity.ToTable("Mouse");

                entity.Property(e => e.MouseId).HasColumnName("Mouse_ID");

                entity.Property(e => e.MouseType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mouse_Type");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SocialSecurity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Student_Name");

                entity.Property(e => e.StudentNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Student_Number");

                entity.Property(e => e.ZipCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.TicketId).HasColumnName("Ticket_ID");

                entity.Property(e => e.BorrowDate)
                    .HasColumnType("date")
                    .HasColumnName("Borrow_Date");

                entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("date")
                    .HasColumnName("Expiration_Date");

                entity.Property(e => e.KeyboardId).HasColumnName("Keyboard_ID");

                entity.Property(e => e.MouseId).HasColumnName("Mouse_ID");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.HasOne(d => d.Computer)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ComputerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ticket__Computer__18EBB532");

                entity.HasOne(d => d.Keyboard)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.KeyboardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ticket__Keyboard__5EBF139D");

                entity.HasOne(d => d.Mouse)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.MouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ticket__Mouse_ID__6C190EBB");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ticket__Student___49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
