using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DuDatabase.Migrations
{
    public partial class AddedTransactionDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyRaised",
                table: "Committees");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transactions");

            migrationBuilder.AddColumn<float>(
                name: "MoneyRaised",
                table: "Committees",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
