using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using school_register.Data;

namespace school_register.Migrations
{
    [DbContext(typeof(SchoolRegisterDbContext))]
    partial class SchoolRegisterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("school_register.Model.Entities.Branch", b =>
                {
                    b.Property<int>("IdBranch")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idBranch")
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("StartDate")
                        .HasColumnType("date");

                    b.HasKey("IdBranch")
                        .HasName("PK_branch");

                    b.ToTable("branch");
                });

            modelBuilder.Entity("school_register.Model.Entities.Classes", b =>
                {
                    b.Property<int>("IdClass")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idClass")
                        .HasColumnType("int(11)");

                    b.Property<int>("FkBranch")
                        .HasColumnName("fk_branch")
                        .HasColumnType("int(11)");

                    b.Property<int>("FkRoom")
                        .HasColumnName("fk_room")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("char(8)");

                    b.HasKey("IdClass")
                        .HasName("PK_classes");

                    b.HasIndex("FkBranch")
                        .HasName("fk_classes_branch1_idx");

                    b.HasIndex("FkRoom")
                        .HasName("fk_classes_rooms1_idx");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("school_register.Model.Entities.Rooms", b =>
                {
                    b.Property<int>("IdRoom")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idRoom")
                        .HasColumnType("int(11)");

                    b.Property<int>("Floor")
                        .HasColumnType("int(11)");

                    b.Property<bool>("Lim")
                        .HasColumnName("LIM")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NumeroAula")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.HasKey("IdRoom")
                        .HasName("PK_rooms");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("school_register.Model.Entities.Students", b =>
                {
                    b.Property<string>("FiscalCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(16)");

                    b.Property<int>("Age")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnName("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(80)");

                    b.Property<int>("FkClass")
                        .HasColumnName("fk_class")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.HasKey("FiscalCode")
                        .HasName("PK_students");

                    b.HasIndex("FkClass")
                        .HasName("fk_students_classes1_idx");

                    b.ToTable("students");
                });

            modelBuilder.Entity("school_register.Model.Entities.Classes", b =>
                {
                    b.HasOne("school_register.Model.Entities.Branch", "FkBranchNavigation")
                        .WithMany("Classes")
                        .HasForeignKey("FkBranch")
                        .HasConstraintName("fk_classes_branch");

                    b.HasOne("school_register.Model.Entities.Rooms", "FkRoomNavigation")
                        .WithMany("Classes")
                        .HasForeignKey("FkRoom");
                });

            modelBuilder.Entity("school_register.Model.Entities.Students", b =>
                {
                    b.HasOne("school_register.Model.Entities.Classes", "FkClassNavigation")
                        .WithMany("Students")
                        .HasForeignKey("FkClass")
                        .HasConstraintName("fk_students_classes");
                });
        }
    }
}
