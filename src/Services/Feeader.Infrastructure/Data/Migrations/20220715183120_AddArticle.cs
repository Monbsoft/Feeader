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
                    FeedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5660e7b9-7555-4d3f-b863-df658440820b"),
                column: "Created",
                value: new DateTime(2022, 7, 15, 20, 31, 19, 866, DateTimeKind.Local).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("5ebb45a0-5fff-49ac-a5d5-691e6314ce71"),
                column: "Created",
                value: new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("71a2df8c-cb34-4203-b045-375695439b8b"),
                column: "Created",
                value: new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3464));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("bcb81fd8-ab1d-4874-af23-35513d3d673d"),
                column: "Created",
                value: new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3457));

            migrationBuilder.UpdateData(
                table: "Feeds",
                keyColumn: "Id",
                keyValue: new Guid("cbab58bb-fa24-46b9-b68d-ee25ddefb1a6"),
                column: "Created",
                value: new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3440));

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
