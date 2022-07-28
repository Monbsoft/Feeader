using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monbsoft.Feeader.Infrastructure.Data.Migrations
{
    public partial class ChangeArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Feeds_FeedId",
                table: "Articles");

            migrationBuilder.AlterColumn<Guid>(
                name: "FeedId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5660e7b9-7555-4d3f-b863-df658440820b"),
                column: "Created",
                value: new DateTime(2022, 7, 22, 23, 23, 26, 31, DateTimeKind.Local).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5ebb45a0-5fff-49ac-a5d5-691e6314ce71"),
                column: "Created",
                value: new DateTime(2022, 7, 22, 23, 23, 26, 34, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("71a2df8c-cb34-4203-b045-375695439b8b"),
                column: "Created",
                value: new DateTime(2022, 7, 22, 23, 23, 26, 34, DateTimeKind.Local).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("bcb81fd8-ab1d-4874-af23-35513d3d673d"),
                column: "Created",
                value: new DateTime(2022, 7, 22, 23, 23, 26, 34, DateTimeKind.Local).AddTicks(2485));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("cbab58bb-fa24-46b9-b68d-ee25ddefb1a6"),
                column: "Created",
                value: new DateTime(2022, 7, 22, 23, 23, 26, 34, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Feeds_FeedId",
                table: "Articles",
                column: "FeedId",
                principalTable: "Feeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Feeds_FeedId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Articles");

            migrationBuilder.AlterColumn<Guid>(
                name: "FeedId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5660e7b9-7555-4d3f-b863-df658440820b"),
                column: "Created",
                value: new DateTime(2022, 7, 16, 15, 49, 33, 948, DateTimeKind.Local).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5ebb45a0-5fff-49ac-a5d5-691e6314ce71"),
                column: "Created",
                value: new DateTime(2022, 7, 16, 15, 49, 33, 951, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("71a2df8c-cb34-4203-b045-375695439b8b"),
                column: "Created",
                value: new DateTime(2022, 7, 16, 15, 49, 33, 951, DateTimeKind.Local).AddTicks(6497));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("bcb81fd8-ab1d-4874-af23-35513d3d673d"),
                column: "Created",
                value: new DateTime(2022, 7, 16, 15, 49, 33, 951, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("cbab58bb-fa24-46b9-b68d-ee25ddefb1a6"),
                column: "Created",
                value: new DateTime(2022, 7, 16, 15, 49, 33, 951, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Feeds_FeedId",
                table: "Articles",
                column: "FeedId",
                principalTable: "Feeds",
                principalColumn: "Id");
        }
    }
}
