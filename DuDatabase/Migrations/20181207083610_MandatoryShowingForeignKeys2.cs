using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DuDatabase.Migrations
{
    public partial class MandatoryShowingForeignKeys2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Dues_DuesId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_DuesId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DuesId",
                table: "Members");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentPlan",
                table: "Dues",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Dues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dues_MemberId",
                table: "Dues",
                column: "MemberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dues_Members_MemberId",
                table: "Dues",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dues_Members_MemberId",
                table: "Dues");

            migrationBuilder.DropIndex(
                name: "IX_Dues_MemberId",
                table: "Dues");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Dues");

            migrationBuilder.AddColumn<int>(
                name: "DuesId",
                table: "Members",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "PaymentPlan",
                table: "Dues",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_DuesId",
                table: "Members",
                column: "DuesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Dues_DuesId",
                table: "Members",
                column: "DuesId",
                principalTable: "Dues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
