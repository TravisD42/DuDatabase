using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DuDatabase.Migrations
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeMembers_Committees_CommitteeId",
                table: "CommitteeMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeMembers_Members_MemberId",
                table: "CommitteeMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommitteeMembers",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Committees");

            migrationBuilder.RenameTable(
                name: "CommitteeMembers",
                newName: "CommitteehasMembers");

            migrationBuilder.RenameIndex(
                name: "IX_CommitteeMembers_MemberId",
                table: "CommitteehasMembers",
                newName: "IX_CommitteehasMembers_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_CommitteeMembers_CommitteeId",
                table: "CommitteehasMembers",
                newName: "IX_CommitteehasMembers_CommitteeId");

            migrationBuilder.AddColumn<float>(
                name: "MoneyRaised",
                table: "Committees",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommitteehasMembers",
                table: "CommitteehasMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteehasMembers_Committees_CommitteeId",
                table: "CommitteehasMembers",
                column: "CommitteeId",
                principalTable: "Committees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteehasMembers_Members_MemberId",
                table: "CommitteehasMembers",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommitteehasMembers_Committees_CommitteeId",
                table: "CommitteehasMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommitteehasMembers_Members_MemberId",
                table: "CommitteehasMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommitteehasMembers",
                table: "CommitteehasMembers");

            migrationBuilder.DropColumn(
                name: "MoneyRaised",
                table: "Committees");

            migrationBuilder.RenameTable(
                name: "CommitteehasMembers",
                newName: "CommitteeMembers");

            migrationBuilder.RenameIndex(
                name: "IX_CommitteehasMembers_MemberId",
                table: "CommitteeMembers",
                newName: "IX_CommitteeMembers_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_CommitteehasMembers_CommitteeId",
                table: "CommitteeMembers",
                newName: "IX_CommitteeMembers_CommitteeId");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Committees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommitteeMembers",
                table: "CommitteeMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeMembers_Committees_CommitteeId",
                table: "CommitteeMembers",
                column: "CommitteeId",
                principalTable: "Committees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeMembers_Members_MemberId",
                table: "CommitteeMembers",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
