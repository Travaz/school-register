using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using school_register.Model.Entities;

namespace school_register.Data
{
    public partial class SchoolRegisterDbContext : DbContext
    {
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        public SchoolRegisterDbContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.IdBranch)
                    .HasName("PK_branch");

                entity.ToTable("branch");

                entity.Property(e => e.IdBranch)
                    .HasColumnName("idBranch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK_class");

                entity.ToTable("class");

                entity.HasIndex(e => e.FkBranch)
                    .HasName("fk_classes_branch1_idx");

                entity.HasIndex(e => e.FkRoom)
                    .HasName("fk_classes_rooms1_idx");

                entity.Property(e => e.Name).HasColumnType("char(8)");

                entity.Property(e => e.FkBranch)
                    .HasColumnName("fk_branch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkRoom)
                    .HasColumnName("fk_room")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkBranchNavigation)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.FkBranch)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_classes_branch");

                entity.HasOne(d => d.FkRoomNavigation)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.FkRoom)
                    .HasConstraintName("fk_classes_rooms");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("PK_room");

                entity.ToTable("room");

                entity.Property(e => e.IdRoom)
                    .HasColumnName("idRoom")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Floor).HasColumnType("int(11)");

                entity.Property(e => e.Lim)
                    .HasColumnName("LIM")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.NumeroAula).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_student");

                entity.ToTable("student");

                entity.HasIndex(e => e.FkClass)
                    .HasName("fk_student_class1_idx");

                entity.Property(e => e.FiscalCode)
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.Age)
                    .HasColumnType("int(11)");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.FkClass)
                    .IsRequired()
                    .HasColumnName("fk_class")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(80)");

                entity.HasOne(d => d.FkClassNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.FkClass)
                    .HasConstraintName("fk_student_class");
            });
        }
    }
}