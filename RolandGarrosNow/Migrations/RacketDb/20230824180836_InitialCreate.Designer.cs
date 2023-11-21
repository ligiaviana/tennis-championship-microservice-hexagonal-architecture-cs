﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TennisChampionshipMicroservice.Adapters.SqliteAdapters;

#nullable disable

namespace TennisChampionshipMicroservice.Migrations.RacketDb
{
    [DbContext(typeof(RacketDbContext))]
    [Migration("20230824180836_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("TennisChampionshipMicroservice.Models.Entities.RacketEntity", b =>
                {
                    b.Property<int>("RacketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MainColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MainComposition")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<double>("StringTension")
                        .HasColumnType("REAL");

                    b.HasKey("RacketId");

                    b.ToTable("Rackets");
                });
#pragma warning restore 612, 618
        }
    }
}
