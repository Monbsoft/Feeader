using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monbsoft.Feeader.Infrastructure.Data.Migrations
{
    public partial class AddArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Articles_FeedId",
                table: "Articles",
                column: "FeedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5660e7b9-7555-4d3f-b863-df658440820b"),
                column: "Created",
                value: new DateTime(2022, 7, 15, 20, 26, 37, 77, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5ebb45a0-5fff-49ac-a5d5-691e6314ce71"),
                column: "Created",
                value: new DateTime(2022, 7, 15, 20, 26, 37, 80, DateTimeKind.Local).AddTicks(8585));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("71a2df8c-cb34-4203-b045-375695439b8b"),
                column: "Created",
                value: new DateTime(2022, 7, 15, 20, 26, 37, 80, DateTimeKind.Local).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("bcb81fd8-ab1d-4874-af23-35513d3d673d"),
                column: "Created",
                value: new DateTime(2022, 7, 15, 20, 26, 37, 80, DateTimeKind.Local).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("cbab58bb-fa24-46b9-b68d-ee25ddefb1a6"),
                column: "Created",
                value: new DateTime(2022, 7, 15, 20, 26, 37, 80, DateTimeKind.Local).AddTicks(8563));
        }
    }
}
