using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using school_register.Model.Entities;

namespace school_register.Data
{
    public partial class SchoolRegisterDbContext : DbContext
    {
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySql(@"Server=localhost;database=school-register-showroom;uid=root;pwd=root;");
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
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.IdClass)
                    .HasName("PK_classes");

                entity.ToTable("classes");

                entity.HasIndex(e => e.FkBranch)
                    .HasName("fk_classes_branch1_idx");

                entity.HasIndex(e => e.FkRoom)
                    .HasName("fk_classes_rooms1_idx");

                entity.Property(e => e.IdClass)
                    .HasColumnName("idClass")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkBranch)
                    .HasColumnName("fk_branch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkRoom)
                    .HasColumnName("fk_room")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(8)");

                entity.HasOne(d => d.FkBranchNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.FkBranch)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_classes_branch");

                entity.HasOne(d => d.FkRoomNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.FkRoom)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_classes_rooms");
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("PK_rooms");

                entity.ToTable("rooms");

                entity.Property(e => e.IdRoom)
                    .HasColumnName("idRoom")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Floor).HasColumnType("int(11)");

                entity.Property(e => e.Lim)
                    .HasColumnName("LIM")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.NumeroAula)
                    .IsRequired()
                    .HasColumnType("char(3)");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.FiscalCode)
                    .HasName("PK_students");

                entity.ToTable("students");

                entity.HasIndex(e => e.FkClass)
                    .HasName("fk_students_classes1_idx");

                entity.Property(e => e.FiscalCode).HasColumnType("varchar(16)");

                entity.Property(e => e.Age).HasColumnType("int(11)");

                entity.Property(e => e.Email).HasColumnType("varchar(80)");

                entity.Property(e => e.FkClass)
                    .HasColumnName("fk_class")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.Birthday)
                    .IsRequired()
                    .HasColumnName("Birthday")
                    .HasColumnType("date");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(80)");

                entity.HasOne(d => d.FkClassNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FkClass)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_students_classes");
            });
        }
    }
}