﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using school_register.Data;
using school_register.Models;

namespace school_register.Migrations
{
    [DbContext(typeof(SchoolRegisterDbContext))]
    [Migration("20170510192735_Definitive#1")]
    partial class Definitive1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("school_register.Models.Branch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("ID")
                        .HasName("PK_branch");

                    b.ToTable("branch");
                });

            modelBuilder.Entity("school_register.Models.Class", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FkBranch")
                        .HasColumnName("fk_branch")
                        .HasColumnType("int(11)");

                    b.Property<int?>("FkRoom")
                        .HasColumnName("fk_room")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .HasColumnType("char(8)");

                    b.HasKey("ID")
                        .HasName("PK_class");

                    b.HasIndex("FkBranch")
                        .HasName("fk_classes_branch1_idx");

                    b.HasIndex("FkRoom")
                        .HasName("fk_classes_rooms1_idx");

                    b.ToTable("class");
                });

            modelBuilder.Entity("school_register.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Floor")
                        .HasColumnType("int(11)");

                    b.Property<bool>("Lim")
                        .HasColumnName("LIM")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("NumeroAula")
                        .HasColumnType("int(11)");

                    b.HasKey("ID")
                        .HasName("PK_room");

                    b.ToTable("room");
                });

            modelBuilder.Entity("school_register.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("FiscalCode")
                        .HasColumnType("varchar(16)");

                    b.Property<int?>("FkClass")
                        .IsRequired()
                        .HasColumnName("fk_class")
                        .HasColumnType("int(11)");

                    b.Property<int>("Gender")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.HasKey("ID")
                        .HasName("PK_student");

                    b.HasIndex("FkClass")
                        .HasName("fk_student_class1_idx");

                    b.ToTable("student");
                });

            modelBuilder.Entity("school_register.Models.Class", b =>
                {
                    b.HasOne("school_register.Models.Branch", "FkBranchNavigation")
                        .WithMany("Classes")
                        .HasForeignKey("FkBranch")
                        .HasConstraintName("fk_classes_branch")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("school_register.Models.Room", "FkRoomNavigation")
                        .WithMany("Classes")
                        .HasForeignKey("FkRoom")
                        .HasConstraintName("fk_classes_rooms")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("school_register.Models.Student", b =>
                {
                    b.HasOne("school_register.Models.Class", "FkClassNavigation")
                        .WithMany("Students")
                        .HasForeignKey("FkClass")
                        .HasConstraintName("fk_student_class")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
