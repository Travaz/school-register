using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace school_register.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "branch",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Floor = table.Column<int>(type: "int(11)", nullable: false),
                    LIM = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NumeroAula = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    fk_branch = table.Column<int>(type: "int(11)", nullable: true),
                    fk_room = table.Column<int>(type: "int(11)", nullable: true),
                    Name = table.Column<string>(type: "char(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.ID);
                    table.ForeignKey(
                        name: "fk_classes_branch",
                        column: x => x.fk_branch,
                        principalTable: "branch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_classes_rooms",
                        column: x => x.fk_room,
                        principalTable: "room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Age = table.Column<int>(type: "int(11)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", nullable: true),
                    FiscalCode = table.Column<string>(type: "varchar(16)", nullable: false),
                    fk_class = table.Column<int>(type: "int(11)", nullable: false),
                    Gender = table.Column<int>(type: "int(11)", nullable: false),
                    Name = table.Column<string>(type: "varchar(80)", nullable: false),
                    Surname = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.ID);
                    table.ForeignKey(
                        name: "fk_student_class",
                        column: x => x.fk_class,
                        principalTable: "class",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "fk_classes_branch1_idx",
                table: "class",
                column: "fk_branch");

            migrationBuilder.CreateIndex(
                name: "fk_classes_rooms1_idx",
                table: "class",
                column: "fk_room");

            migrationBuilder.CreateIndex(
                name: "fk_student_class1_idx",
                table: "student",
                column: "fk_class");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "branch");

            migrationBuilder.DropTable(
                name: "room");
        }
    }
}
