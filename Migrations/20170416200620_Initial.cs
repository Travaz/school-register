using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace school_register.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "branch",
                columns: table => new
                {
                    idBranch = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(type: "varchar(45)", nullable: false),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch", x => x.idBranch);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    idRoom = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Floor = table.Column<int>(type: "int(11)", nullable: false),
                    LIM = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NumeroAula = table.Column<string>(type: "char(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.idRoom);
                });

            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    idClass = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    fk_branch = table.Column<int>(type: "int(11)", nullable: false),
                    fk_room = table.Column<int>(type: "int(11)", nullable: false),
                    Name = table.Column<string>(type: "char(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.idClass);
                    table.ForeignKey(
                        name: "fk_classes_branch",
                        column: x => x.fk_branch,
                        principalTable: "branch",
                        principalColumn: "idBranch",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_classes_rooms_fk_room",
                        column: x => x.fk_room,
                        principalTable: "rooms",
                        principalColumn: "idRoom",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    FiscalCode = table.Column<string>(type: "varchar(16)", nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Age = table.Column<int>(type: "int(11)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", nullable: true),
                    fk_class = table.Column<int>(type: "int(11)", nullable: false),
                    Name = table.Column<string>(type: "varchar(80)", nullable: false),
                    Surname = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.FiscalCode);
                    table.ForeignKey(
                        name: "fk_students_classes",
                        column: x => x.fk_class,
                        principalTable: "classes",
                        principalColumn: "idClass",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_classes_branch1_idx",
                table: "classes",
                column: "fk_branch");

            migrationBuilder.CreateIndex(
                name: "fk_classes_rooms1_idx",
                table: "classes",
                column: "fk_room");

            migrationBuilder.CreateIndex(
                name: "fk_students_classes1_idx",
                table: "students",
                column: "fk_class");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "branch");

            migrationBuilder.DropTable(
                name: "rooms");
        }
    }
}
