﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OLXWebApi.Data.DbContexts;

#nullable disable

namespace OLXWebApi.Migrations
{
    [DbContext(typeof(OlxDbContext))]
    [Migration("20230816073357_s")]
    partial class s
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OLXWebApi.Domain.Entities.Announcement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<byte[]>("Awatars")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("OLXWebApi.Domain.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("OLXWebApi.Domain.Entities.MyAds", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("AnnouncementId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AnnouncementId");

                    b.HasIndex("UserId");

                    b.ToTable("MyAds");
                });

            modelBuilder.Entity("OLXWebApi.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<byte?>("Awatar")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2023, 8, 16, 7, 33, 57, 152, DateTimeKind.Utc).AddTicks(576),
                            Email = "dotnetgo@icloud.com",
                            Firstname = "Mukhammadkarim",
                            IsActive = true,
                            Lastname = "Tukhtaboyev",
                            Password = "$2a$11$f0qrXfOdStj0cTVrJ.e7XuDEDz25O1gwLMvisu59Y48pSx8WM4SdS",
                            UserRole = 0
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2023, 8, 16, 7, 33, 57, 351, DateTimeKind.Utc).AddTicks(6522),
                            Email = "wonderboy1w3@gmail.com",
                            Firstname = "Jamshid",
                            IsActive = true,
                            Lastname = "Ma'ruf",
                            Password = "$2a$11$5YF31o0NP8j60ciGprxAiesacJDnfQlyGAO0yQcY6T1rSAnfj8HZu",
                            UserRole = 0
                        });
                });

            modelBuilder.Entity("OLXWebApi.Domain.Entities.Announcement", b =>
                {
                    b.HasOne("OLXWebApi.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OLXWebApi.Domain.Entities.User", "User")
                        .WithMany("MyAnnouncementList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OLXWebApi.Domain.Entities.MyAds", b =>
                {
                    b.HasOne("OLXWebApi.Domain.Entities.Announcement", "Announcement")
                        .WithMany()
                        .HasForeignKey("AnnouncementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OLXWebApi.Domain.Entities.User", null)
                        .WithMany("MyAdsList")
                        .HasForeignKey("UserId");

                    b.Navigation("Announcement");
                });

            modelBuilder.Entity("OLXWebApi.Domain.Entities.User", b =>
                {
                    b.Navigation("MyAdsList");

                    b.Navigation("MyAnnouncementList");
                });
#pragma warning restore 612, 618
        }
    }
}
