﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTask.Data;

namespace TestTask.Migrations
{
    [DbContext(typeof(TestTaskContext))]
    [Migration("20200803092311_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherTestTask.Weather.WeatherDatum", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AirWetness")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Pressure")
                        .HasColumnType("int");

                    b.Property<decimal>("Td")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TemperatureC")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("WindDirection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cloudness")
                        .HasColumnType("int");

                    b.Property<int>("h")
                        .HasColumnType("int");

                    b.Property<string>("veatherEffects")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("vv")
                        .HasColumnType("int");

                    b.Property<int>("windSpeed")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("WeatherDatum");
                });
#pragma warning restore 612, 618
        }
    }
}