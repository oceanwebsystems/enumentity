﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OceanWebSystems.EnumEntity.Sample;

#nullable disable

namespace OceanWebSystems.EnumEntity.Sample.Migrations
{
    [DbContext(typeof(TrainingDbContext))]
    [Migration("20211124094042_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OceanWebSystems.EnumEntity.EnumEntity<OceanWebSystems.EnumEntity.Sample.AdministrativeRegion>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AdministrativeRegion", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "West",
                            Value = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "South East",
                            Value = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "East",
                            Value = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "North",
                            Value = 4
                        });
                });

            modelBuilder.Entity("OceanWebSystems.EnumEntity.EnumEntity<OceanWebSystems.EnumEntity.Sample.ProgrammeClass>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProgrammeClass", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Medical",
                            Order = 1,
                            Value = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dental",
                            Order = 2,
                            Value = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Healthcare Science",
                            Order = 8,
                            Value = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Psychology",
                            Order = 4,
                            Value = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "Pharmacy",
                            Order = 3,
                            Value = 5
                        },
                        new
                        {
                            Id = 6,
                            Name = "Social Care",
                            Order = 7,
                            Value = 6
                        },
                        new
                        {
                            Id = 7,
                            Name = "General",
                            Order = 9,
                            Value = 7
                        },
                        new
                        {
                            Id = 8,
                            Name = "Optometry",
                            Order = 5,
                            Value = 8
                        },
                        new
                        {
                            Id = 9,
                            Name = "Covid",
                            Order = 11,
                            Value = 9
                        },
                        new
                        {
                            Id = 10,
                            Name = "Nursing",
                            Order = 6,
                            Value = 10
                        },
                        new
                        {
                            Id = 11,
                            Name = "Dental SQA Activity",
                            Order = 10,
                            Value = 11
                        });
                });

            modelBuilder.Entity("OceanWebSystems.EnumEntity.Sample.Programme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdministrativeRegion")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgrammeClass")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdministrativeRegion");

                    b.HasIndex("ProgrammeClass");

                    b.ToTable("Programme");
                });

            modelBuilder.Entity("OceanWebSystems.EnumEntity.Sample.Programme", b =>
                {
                    b.HasOne("OceanWebSystems.EnumEntity.EnumEntity<OceanWebSystems.EnumEntity.Sample.AdministrativeRegion>", null)
                        .WithMany()
                        .HasForeignKey("AdministrativeRegion")
                        .HasPrincipalKey("Value");

                    b.HasOne("OceanWebSystems.EnumEntity.EnumEntity<OceanWebSystems.EnumEntity.Sample.ProgrammeClass>", null)
                        .WithMany()
                        .HasForeignKey("ProgrammeClass")
                        .HasPrincipalKey("Value")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}