using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monbsoft.Feeader.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeds", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Feeds",
                columns: new[] { "Id", "Created", "Name", "Url" },
                values: new object[,]
                {
                    { new Guid("5660e7b9-7555-4d3f-b863-df658440820b"), new DateTime(2022, 7, 15, 20, 26, 37, 77, DateTimeKind.Local).AddTicks(4041), "BBC News", "http://feeds.bbci.co.uk/news/world/rss.xml" },
                    { new Guid("5ebb45a0-5fff-49ac-a5d5-691e6314ce71"), new DateTime(2022, 7, 15, 20, 26, 37, 80, DateTimeKind.Local).AddTicks(8585), "CNBC", "https://www.cnbc.com/id/100727362/device/rss/rss.html" },
                    { new Guid("71a2df8c-cb34-4203-b045-375695439b8b"), new DateTime(2022, 7, 15, 20, 26, 37, 80, DateTimeKind.Local).AddTicks(8590), "The Washington Post", "https://feeds.washingtonpost.com/rss/world" },
                    { new Guid("bcb81fd8-ab1d-4874-af23-35513d3d673d"), new DateTime(2022, 7, 15, 20, 26, 37, 80, DateTimeKind.Local).AddTicks(8581), "CNN", "http://rss.cnn.com/rss/edition_world.rss" },
                    { new Guid("cbab58bb-fa24-46b9-b68d-ee25ddefb1a6"), new DateTime(2022, 7, 15, 20, 26, 37, 80, DateTimeKind.Local).AddTicks(8563), "The New York Times", "https://www.nytimes.com/svc/collections/v1/publish/https://www.nytimes.com/section/world/rss.xml" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feeds");
        }
    }
}
