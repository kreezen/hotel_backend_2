using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBackendV2.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdToActivityAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Customers_CustomerId",
                table: "Activity");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Activity",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId1",
                table: "Activity",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_CustomerId1",
                table: "Activity",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Customers_CustomerId",
                table: "Activity",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Customers_CustomerId1",
                table: "Activity",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Customers_CustomerId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Customers_CustomerId1",
                table: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_CustomerId1",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Activity");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Activity",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Customers_CustomerId",
                table: "Activity",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
