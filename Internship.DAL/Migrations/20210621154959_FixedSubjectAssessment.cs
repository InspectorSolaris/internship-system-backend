using Microsoft.EntityFrameworkCore.Migrations;

namespace Internship.DAL.Migrations
{
    public partial class FixedSubjectAssessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectAssessments_Subjects_SubjectId",
                table: "SubjectAssessments");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "SubjectAssessments",
                newName: "SubjectInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectAssessments_SubjectId",
                table: "SubjectAssessments",
                newName: "IX_SubjectAssessments_SubjectInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectAssessments_SubjectInstances_SubjectInstanceId",
                table: "SubjectAssessments",
                column: "SubjectInstanceId",
                principalTable: "SubjectInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectAssessments_SubjectInstances_SubjectInstanceId",
                table: "SubjectAssessments");

            migrationBuilder.RenameColumn(
                name: "SubjectInstanceId",
                table: "SubjectAssessments",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectAssessments_SubjectInstanceId",
                table: "SubjectAssessments",
                newName: "IX_SubjectAssessments_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectAssessments_Subjects_SubjectId",
                table: "SubjectAssessments",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
