using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerStudent.Infrastructure.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Comment", "LastName", "Name" },
                values: new object[,]
                {
                    { 2, "Buen estudiante", "Velazquez", "Alfredo" },
                    { 3, "Buen estudiante", "Flores", "Maria" },
                    { 4, "Mal estudiante", "Lorenzo", "Ramon" },
                    { 6, "muy Buen estudiante", "Castillo", "Isamal" },
                    { 7, "Buen estudiante", "Monte", "Fernado" },
                    { 8, "Buen estudiante", "Puentes", "Samuel" },
                    { 9, "Mal estudiante", "Perez", "Ana" },
                    { 10, "buen estudiante", "Martinez", "Liz" },
                    { 16, "take attendancetake attendancetake attendancetake attendancetake attendancetake attendance", "Santos", "Fany" },
                    { 17, "", "Manuel", "Junior" },
                    { 18, "", "Carmona", "Gabriel" },
                    { 19, "Buen estudiante", "test", "Update student" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Matematicas" },
                    { 2, "Lengua española" },
                    { 3, "Ciencias Sociales" },
                    { 4, "Ciencias Naturales" },
                    { 5, "Fisica" },
                    { 6, "Artistica" },
                    { 7, "Moral y Civica" }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "Id", "Date", "Status", "StudentId" },
                values: new object[,]
                {
                    { 73, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 2 },
                    { 74, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 3 },
                    { 75, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "E", 4 },
                    { 77, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 6 },
                    { 78, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 7 },
                    { 79, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 8 },
                    { 80, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 9 },
                    { 81, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 10 },
                    { 82, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 16 },
                    { 83, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 17 },
                    { 84, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 18 },
                    { 85, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 2 },
                    { 86, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 3 },
                    { 87, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 4 },
                    { 89, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 6 },
                    { 90, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 7 },
                    { 91, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 8 },
                    { 92, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 9 },
                    { 93, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 10 },
                    { 94, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 16 },
                    { 95, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 17 },
                    { 96, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 18 },
                    { 109, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 2 },
                    { 110, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 3 },
                    { 111, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "E", 4 },
                    { 113, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "E", 6 },
                    { 114, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "E", 7 },
                    { 115, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 8 },
                    { 116, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 9 },
                    { 117, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 10 },
                    { 118, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 16 },
                    { 119, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 17 },
                    { 120, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 18 },
                    { 121, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 2 },
                    { 122, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 3 },
                    { 123, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 4 },
                    { 125, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 6 },
                    { 126, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 7 },
                    { 127, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 8 },
                    { 128, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 9 },
                    { 129, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 10 },
                    { 130, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 16 }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "Id", "Date", "Status", "StudentId" },
                values: new object[,]
                {
                    { 131, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 17 },
                    { 132, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 18 },
                    { 133, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 2 },
                    { 134, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 3 },
                    { 135, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 4 },
                    { 137, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 6 },
                    { 138, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 7 },
                    { 139, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 8 },
                    { 140, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 9 },
                    { 141, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 10 },
                    { 142, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 16 },
                    { 143, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 17 },
                    { 144, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 18 },
                    { 167, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "E", 2 },
                    { 168, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "E", 3 },
                    { 169, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 4 },
                    { 170, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 6 },
                    { 171, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 7 },
                    { 172, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 8 },
                    { 173, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "E", 9 },
                    { 174, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 10 },
                    { 175, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "E", 16 },
                    { 176, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 17 },
                    { 177, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "P", 18 }
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Id", "StudentId", "SubjectId", "Value" },
                values: new object[,]
                {
                    { 2, 2, 1, (byte)70 },
                    { 3, 3, 1, (byte)80 },
                    { 4, 4, 1, (byte)78 },
                    { 6, 6, 1, (byte)98 },
                    { 7, 7, 1, (byte)67 },
                    { 8, 8, 1, (byte)89 },
                    { 9, 9, 1, (byte)78 },
                    { 10, 10, 1, (byte)97 },
                    { 11, 16, 1, (byte)98 },
                    { 12, 17, 1, (byte)87 },
                    { 16, 2, 2, (byte)87 },
                    { 17, 3, 2, (byte)67 },
                    { 18, 4, 2, (byte)87 },
                    { 20, 6, 2, (byte)86 },
                    { 21, 8, 2, (byte)86 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_StudentId",
                table: "Scores",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_SubjectId",
                table: "Scores",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
