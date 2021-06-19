using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Internship.DAL.Migrations
{
    public partial class FixModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_AspNetUsers_CompanyId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Positions_PositionId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Specializations_SpecializationId",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_SpecializationId",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_CompanyId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Interviews");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Interviews",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Positions",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PositionId",
                table: "Interviews",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "Interviews",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Positions_PositionId",
                table: "Interviews",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Positions_PositionId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Interviews");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Interviews",
                newName: "Result");

            migrationBuilder.AddColumn<Guid>(
                name: "SpecializationId",
                table: "Technologies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PositionId",
                table: "Interviews",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Interviews",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_SpecializationId",
                table: "Technologies",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_CompanyId",
                table: "Interviews",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_AspNetUsers_CompanyId",
                table: "Interviews",
                column: "CompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Positions_PositionId",
                table: "Interviews",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Specializations_SpecializationId",
                table: "Technologies",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
