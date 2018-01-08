using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Actidev.FinancialManagement.Data.Migrations
{
    public partial class ChangeOperationsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncome",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "IsPlanned",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Types",
                table: "Operations");

            migrationBuilder.RenameColumn(
                name: "PlannedDate",
                table: "Operations",
                newName: "AccrualDate");

            migrationBuilder.AddColumn<int>(
                name: "AccrualOperationType",
                table: "Operations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Operations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccrualOperationType",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Operations");

            migrationBuilder.RenameColumn(
                name: "AccrualDate",
                table: "Operations",
                newName: "PlannedDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsIncome",
                table: "Operations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlanned",
                table: "Operations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Types",
                table: "Operations",
                nullable: false,
                defaultValue: 0);
        }
    }
}
