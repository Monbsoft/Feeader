﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monbsoft.Feeader.Infrastructure.Data;

#nullable disable

namespace Monbsoft.Feeader.Infrastructure.Data.Migrations
{
    [DbContext(typeof(FeeaderDbContext))]
    partial class FeeaderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Monbsoft.Feeader.Domain.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FeedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Monbsoft.Feeader.Domain.Feed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Feeds");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5660e7b9-7555-4d3f-b863-df658440820b"),
                            Created = new DateTime(2022, 7, 15, 20, 31, 19, 866, DateTimeKind.Local).AddTicks(5490),
                            Name = "BBC News",
                            Updated = new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(1432),
                            Url = "http://feeds.bbci.co.uk/news/world/rss.xml"
                        },
                        new
                        {
                            Id = new Guid("cbab58bb-fa24-46b9-b68d-ee25ddefb1a6"),
                            Created = new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3440),
                            Name = "The New York Times",
                            Updated = new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3450),
                            Url = "https://www.nytimes.com/svc/collections/v1/publish/https://www.nytimes.com/section/world/rss.xml"
                        },
                        new
                        {
                            Id = new Guid("bcb81fd8-ab1d-4874-af23-35513d3d673d"),
                            Created = new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3457),
                            Name = "CNN",
                            Updated = new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3458),
                            Url = "http://rss.cnn.com/rss/edition_world.rss"
                        },
                        new
                        {
                            Id = new Guid("5ebb45a0-5fff-49ac-a5d5-691e6314ce71"),
                            Created = new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3461),
                            Name = "CNBC",
                            Updated = new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3462),
                            Url = "https://www.cnbc.com/id/100727362/device/rss/rss.html"
                        },
                        new
                        {
                            Id = new Guid("71a2df8c-cb34-4203-b045-375695439b8b"),
                            Created = new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3464),
                            Name = "The Washington Post",
                            Updated = new DateTime(2022, 7, 15, 20, 31, 19, 870, DateTimeKind.Local).AddTicks(3466),
                            Url = "https://feeds.washingtonpost.com/rss/world"
                        });
                });

            modelBuilder.Entity("Monbsoft.Feeader.Domain.Article", b =>
                {
                    b.HasOne("Monbsoft.Feeader.Domain.Feed", "Feed")
                        .WithMany("Articles")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feed");
                });

            modelBuilder.Entity("Monbsoft.Feeader.Domain.Feed", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
