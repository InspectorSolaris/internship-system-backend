using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Internship.DAL.Migrations
{
    public partial class FixSubjectInstanceRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "SubjectInstances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInstances_SubjectId",
                table: "SubjectInstances",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectInstances_Subjects_SubjectId",
                table: "SubjectInstances",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectInstances_Subjects_SubjectId",
                table: "SubjectInstances");

            migrationBuilder.DropIndex(
                name: "IX_SubjectInstances_SubjectId",
                table: "SubjectInstances");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "SubjectInstances");
        }
    }
}
