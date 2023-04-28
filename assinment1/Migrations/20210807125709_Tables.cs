using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace assinment1.Migrations
{
    public partial class Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    Hall_Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.Hall_Code);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Course_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours_Per_week = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_code);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Professor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Professor_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teaching_Load = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Professor_Id);
                });

            migrationBuilder.CreateTable(
                name: "Professor_Courses",
                columns: table => new
                {
                    Course_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Prof_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor_Courses", x => new { x.Prof_Id, x.Course_code });
                    table.ForeignKey(
                        name: "FK_Professor_Courses_Courses_Course_code",
                        column: x => x.Course_code,
                        principalTable: "Courses",
                        principalColumn: "Course_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professor_Courses_Professors_Prof_Id",
                        column: x => x.Prof_Id,
                        principalTable: "Professors",
                        principalColumn: "Professor_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Section_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Professor_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hall_Num = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Section_Id);
                    table.ForeignKey(
                        name: "FK_Sections_ClassRooms_Hall_Num",
                        column: x => x.Hall_Num,
                        principalTable: "ClassRooms",
                        principalColumn: "Hall_Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_Course_Code",
                        column: x => x.Course_Code,
                        principalTable: "Courses",
                        principalColumn: "Course_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sections_Professors_Professor_Id",
                        column: x => x.Professor_Id,
                        principalTable: "Professors",
                        principalColumn: "Professor_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professor_Courses_Course_code",
                table: "Professor_Courses",
                column: "Course_code");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Course_Code",
                table: "Sections",
                column: "Course_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Hall_Num",
                table: "Sections",
                column: "Hall_Num");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Professor_Id",
                table: "Sections",
                column: "Professor_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professor_Courses");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Professors");
        }
    }
}
