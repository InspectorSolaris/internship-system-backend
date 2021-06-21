using Microsoft.EntityFrameworkCore.Migrations;

namespace Internship.DAL.Migrations
{
    public partial class AddSubjectAssessmentValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "SubjectAssessments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "SubjectAssessments");
        }
    }
}
