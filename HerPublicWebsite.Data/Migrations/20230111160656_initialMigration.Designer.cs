﻿// <auto-generated />
using System;
using HerPublicWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HerPublicWebsite.Data.Migrations
{
    [DbContext(typeof(HerDbContext))]
    [Migration("20230111160656_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HerPublicWebsite.BusinessLogic.Models.ContactDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("ConsentedToAnswerEmail")
                        .HasColumnType("boolean");

                    b.Property<bool>("ConsentedToReferral")
                        .HasColumnType("boolean");

                    b.Property<bool>("ConsentedToSchemeNotificationEmails")
                        .HasColumnType("boolean");

                    b.Property<int>("ContactPreference")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<int>("QuestionnaireId")
                        .HasColumnType("integer");

                    b.Property<string>("Telephone")
                        .HasColumnType("text");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid");

                    b.HasKey("Id");

                    b.HasIndex("QuestionnaireId")
                        .IsUnique();

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("HerPublicWebsite.BusinessLogic.Models.Questionnaire", b =>
                {
                    b.Property<int>("QuestionnaireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionnaireId"));

                    b.Property<string>("AddressLine1")
                        .HasColumnType("text");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("text");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("text");

                    b.Property<string>("AddressPostcode")
                        .HasColumnType("text");

                    b.Property<string>("AddressTown")
                        .HasColumnType("text");

                    b.Property<int>("EpcRating")
                        .HasColumnType("integer");

                    b.Property<int>("HasGasBoiler")
                        .HasColumnType("integer");

                    b.Property<string>("Hug2ReferralId")
                        .HasColumnType("text");

                    b.Property<int>("IncomeBand")
                        .HasColumnType("integer");

                    b.Property<bool>("IsEligibleForHug2")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLsoaProperty")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ReferralCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Uprn")
                        .HasColumnType("text");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid");

                    b.HasKey("QuestionnaireId");

                    b.ToTable("Questionnaires");
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

            modelBuilder.Entity("HerPublicWebsite.BusinessLogic.Models.ContactDetails", b =>
                {
                    b.HasOne("HerPublicWebsite.BusinessLogic.Models.Questionnaire", null)
                        .WithOne("ContactDetails")
                        .HasForeignKey("HerPublicWebsite.BusinessLogic.Models.ContactDetails", "QuestionnaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HerPublicWebsite.BusinessLogic.Models.Questionnaire", b =>
                {
                    b.Navigation("ContactDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
