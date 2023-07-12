﻿// <auto-generated />
using System;
using Competition.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Competition.API.Models;

#nullable disable

namespace Competition.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230707204525_FixedForeignKeys")]
    partial class FixedForeignKeys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetCRM.API.Models.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("PetCRM.API.Models.CompetitionRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipiantDisciplineId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("ParticipiantDisciplineId");

                    b.ToTable("CompetitionRequests");
                });

            modelBuilder.Entity("PetCRM.API.Models.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("PetCRM.API.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfBuilding")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("PetCRM.API.Models.Participiant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MidName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SportCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Participiants");
                });

            modelBuilder.Entity("PetCRM.API.Models.ParticipiantDiscipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipiantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("ParticipiantId");

                    b.ToTable("ParticipiantDisciplines");
                });

            modelBuilder.Entity("PetCRM.API.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PetCRM.API.Models.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MidName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("PetCRM.API.Models.Competition", b =>
                {
                    b.HasOne("PetCRM.API.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("PetCRM.API.Models.CompetitionRequest", b =>
                {
                    b.HasOne("PetCRM.API.Models.Competition", "Competition")
                        .WithMany("CompetitionRequests")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PetCRM.API.Models.ParticipiantDiscipline", "ParticipiantDiscipline")
                        .WithMany("CompetitionRequests")
                        .HasForeignKey("ParticipiantDisciplineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("ParticipiantDiscipline");
                });

            modelBuilder.Entity("PetCRM.API.Models.Participiant", b =>
                {
                    b.HasOne("PetCRM.API.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PetCRM.API.Models.ParticipiantDiscipline", b =>
                {
                    b.HasOne("PetCRM.API.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetCRM.API.Models.Participiant", "Participiant")
                        .WithMany()
                        .HasForeignKey("ParticipiantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Participiant");
                });

            modelBuilder.Entity("PetCRM.API.Models.Team", b =>
                {
                    b.HasOne("PetCRM.API.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("PetCRM.API.Models.Trainer", b =>
                {
                    b.HasOne("PetCRM.API.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PetCRM.API.Models.Competition", b =>
                {
                    b.Navigation("CompetitionRequests");
                });

            modelBuilder.Entity("PetCRM.API.Models.ParticipiantDiscipline", b =>
                {
                    b.Navigation("CompetitionRequests");
                });
#pragma warning restore 612, 618
        }
    }
}