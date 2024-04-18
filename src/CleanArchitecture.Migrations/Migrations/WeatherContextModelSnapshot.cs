﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
#if (UseSqlServer)
using Microsoft.EntityFrameworkCore.Metadata;
#else
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
#endif
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchitecture.Migrations.Migrations
{
    [DbContext(typeof(WeatherContext))]
    partial class WeatherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
#if (UseSqlServer)
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);
#else
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);
#endif

#if (UseSqlServer)
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);
#else
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);
#endif

            modelBuilder.Entity("CleanArchitecture.Core.Locations.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
#if (UseSqlServer)
                        .HasColumnType("uniqueidentifier");
#else
                        .HasColumnType("uuid");
#endif

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Weather.Entities.WeatherForecast", b =>
                {
                    b.Property<Guid>("Id")
#if (UseSqlServer)
                        .HasColumnType("uniqueidentifier");
#else
                        .HasColumnType("uuid");
#endif

                    b.Property<DateTime>("Date")
#if (UseSqlServer)
                        .HasColumnType("datetime2");
#else
                        .HasColumnType("timestamp with time zone");
#endif

                    b.Property<Guid>("LocationId")
#if (UseSqlServer)
                        .HasColumnType("uniqueidentifier");
#else
                        .HasColumnType("uuid");
#endif

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("WeatherForecasts");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Locations.Entities.Location", b =>
                {
                    b.OwnsOne("CleanArchitecture.Core.Locations.ValueObjects.Coordinates", "Coordinates", b1 =>
                        {
                            b1.Property<Guid>("LocationId")
#if (UseSqlServer)
                        .HasColumnType("uniqueidentifier");
#else
                        .HasColumnType("uuid");
#endif

                            b1.Property<decimal>("Latitude")
#if (UseSqlServer)
                        .HasColumnType("decimal(18,2)")
#else
                        .HasColumnType("numeric")
#endif
                                .HasColumnName("Latitude");

                            b1.Property<decimal>("Longitude")
#if (UseSqlServer)
                        .HasColumnType("decimal(18,2)")
#else
                        .HasColumnType("numeric")
#endif
                                .HasColumnName("Longitude");

                            b1.HasKey("LocationId");

                            b1.ToTable("Locations");

                            b1.WithOwner()
                                .HasForeignKey("LocationId");
                        });

                    b.Navigation("Coordinates")
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitecture.Core.Weather.Entities.WeatherForecast", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Locations.Entities.Location", null)
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CleanArchitecture.Core.Weather.ValueObjects.Temperature", "Temperature", b1 =>
                        {
                            b1.Property<Guid>("WeatherForecastId")
#if (UseSqlServer)
                        .HasColumnType("uniqueidentifier");
#else
                        .HasColumnType("uuid");
#endif

                            b1.Property<int>("Celcius")
#if (UseSqlServer)
                        .HasColumnType("int")
#else
                        .HasColumnType("integer")
#endif
                                .HasColumnName("Temperature");

                            b1.HasKey("WeatherForecastId");

                            b1.ToTable("WeatherForecasts");

                            b1.WithOwner()
                                .HasForeignKey("WeatherForecastId");
                        });

                    b.Navigation("Temperature")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
