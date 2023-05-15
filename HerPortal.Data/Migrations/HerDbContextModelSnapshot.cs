﻿// <auto-generated />
using System;
using HerPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HerPortal.Data.Migrations
{
    [DbContext(typeof(HerDbContext))]
    partial class HerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HerPortal.BusinessLogic.Models.CsvFileDownload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CsvFileDownloadDataCustodianCode")
                        .HasColumnType("text");

                    b.Property<int?>("CsvFileDownloadDataMonth")
                        .HasColumnType("integer");

                    b.Property<int?>("CsvFileDownloadDataYear")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("CsvFileDownloadDataCustodianCode", "CsvFileDownloadDataYear", "CsvFileDownloadDataMonth");

                    b.ToTable("CsvFileDownload");
                });

            modelBuilder.Entity("HerPortal.BusinessLogic.Models.CsvFileDownloadData", b =>
                {
                    b.Property<string>("CustodianCode")
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.Property<int>("Month")
                        .HasColumnType("integer");

                    b.HasKey("CustodianCode", "Year", "Month");

                    b.ToTable("CsvFileDownloadData");
                });

            modelBuilder.Entity("HerPortal.BusinessLogic.Models.LocalAuthority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CustodianCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CustodianCode")
                        .IsUnique();

                    b.ToTable("LocalAuthorities");
                });

            modelBuilder.Entity("HerPortal.BusinessLogic.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<bool>("HasLoggedIn")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LocalAuthorityUser", b =>
                {
                    b.Property<int>("LocalAuthoritiesId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("LocalAuthoritiesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("LocalAuthorityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendlyName")
                        .HasColumnType("text");

                    b.Property<string>("Xml")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("HerPortal.BusinessLogic.Models.CsvFileDownload", b =>
                {
                    b.HasOne("HerPortal.BusinessLogic.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("HerPortal.BusinessLogic.Models.CsvFileDownloadData", null)
                        .WithMany("Downloads")
                        .HasForeignKey("CsvFileDownloadDataCustodianCode", "CsvFileDownloadDataYear", "CsvFileDownloadDataMonth");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LocalAuthorityUser", b =>
                {
                    b.HasOne("HerPortal.BusinessLogic.Models.LocalAuthority", null)
                        .WithMany()
                        .HasForeignKey("LocalAuthoritiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HerPortal.BusinessLogic.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HerPortal.BusinessLogic.Models.CsvFileDownloadData", b =>
                {
                    b.Navigation("Downloads");
                });
#pragma warning restore 612, 618
        }
    }
}
