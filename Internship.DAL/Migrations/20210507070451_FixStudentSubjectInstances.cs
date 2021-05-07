using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Internship.DAL.Migrations
{
    public partial class FixStudentSubjectInstances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectInstanceUser");

            migrationBuilder.CreateTable(
                name: "StudentSubjectInstance",
                columns: table => new
                {
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectInstancesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjectInstance", x => new { x.StudentsId, x.SubjectInstancesId });
                    table.ForeignKey(
                        name: "FK_StudentSubjectInstance_AspNetUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjectInstance_SubjectInstances_SubjectInstancesId",
                        column: x => x.SubjectInstancesId,
                        principalTable: "SubjectInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectInstance_SubjectInstancesId",
                table: "StudentSubjectInstance",
                column: "SubjectInstancesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubjectInstance");

            migrationBuilder.CreateTable(
                name: "SubjectInstanceUser",
                columns: table => new
                {
                    SubjectInstancesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectInstanceUser", x => new { x.SubjectInstancesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SubjectInstanceUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectInstanceUser_SubjectInstances_SubjectInstancesId",
                        column: x => x.SubjectInstancesId,
                        principalTable: "SubjectInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInstanceUser_UsersId",
                table: "SubjectInstanceUser",
                column: "UsersId");
        }
    }
}
