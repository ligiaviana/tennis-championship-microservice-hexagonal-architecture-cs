﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TennisChampionshipMicroservice.Adapters.SqliteAdapters;

#nullable disable

namespace TennisChampionshipMicroservice.Migrations.LaundryDb
{
    [DbContext(typeof(LaundryDbContext))]
    partial class LaundryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("TennisChampionshipMicroservice.Models.Entities.LaundryEntity", b =>
                {
                    b.Property<int>("BagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("PricePerKilogram")
                        .HasColumnType("REAL");

                    b.HasKey("BagId");

                    b.ToTable("Laundry");
                });
#pragma warning restore 612, 618
        }
    }
}
