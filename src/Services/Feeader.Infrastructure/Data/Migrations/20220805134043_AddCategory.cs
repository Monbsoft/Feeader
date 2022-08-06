using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monbsoft.Feeader.Infrastructure.Data.Migrations
{
    public partial class AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Feeds",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5660e7b9-7555-4d3f-b863-df658440820b"),
                column: "Created",
                value: new DateTime(2022, 8, 5, 15, 40, 42, 642, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5ebb45a0-5fff-49ac-a5d5-691e6314ce71"),
                column: "Created",
                value: new DateTime(2022, 8, 5, 15, 40, 42, 646, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("71a2df8c-cb34-4203-b045-375695439b8b"),
                column: "Created",
                value: new DateTime(2022, 8, 5, 15, 40, 42, 646, DateTimeKind.Local).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("bcb81fd8-ab1d-4874-af23-35513d3d673d"),
                column: "Created",
                value: new DateTime(2022, 8, 5, 15, 40, 42, 646, DateTimeKind.Local).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("cbab58bb-fa24-46b9-b68d-ee25ddefb1a6"),
                column: "Created",
                value: new DateTime(2022, 8, 5, 15, 40, 42, 646, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_CategoryId",
                table: "Feeds",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Categories_CategoryId",
                table: "Feeds",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Categories_CategoryId",
                table: "Feeds");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_CategoryId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Feeds");

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5660e7b9-7555-4d3f-b863-df658440820b"),
                column: "Created",
                value: new DateTime(2022, 7, 31, 9, 39, 3, 205, DateTimeKind.Local).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5ebb45a0-5fff-49ac-a5d5-691e6314ce71"),
                column: "Created",
                value: new DateTime(2022, 7, 31, 9, 39, 3, 209, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("71a2df8c-cb34-4203-b045-375695439b8b"),
                column: "Created",
                value: new DateTime(2022, 7, 31, 9, 39, 3, 209, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("bcb81fd8-ab1d-4874-af23-35513d3d673d"),
                column: "Created",
                value: new DateTime(2022, 7, 31, 9, 39, 3, 209, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("cbab58bb-fa24-46b9-b68d-ee25ddefb1a6"),
                column: "Created",
                value: new DateTime(2022, 7, 31, 9, 39, 3, 209, DateTimeKind.Local).AddTicks(2525));
        }
    }
}
