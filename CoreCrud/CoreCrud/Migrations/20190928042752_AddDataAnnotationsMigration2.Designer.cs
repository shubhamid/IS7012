﻿// <auto-generated />
using System;
using CoreCrud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreCrud.Migrations
{
    [DbContext(typeof(CoreCrud09212019Context))]
    [Migration("20190928042752_AddDataAnnotationsMigration2")]
    partial class AddDataAnnotationsMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreCrud.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("CoreCrud.Models.Destination", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<decimal>("AverageTemp")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("CityAgentCellPhone")
                        .HasMaxLength(11);

                    b.Property<string>("CityAgentEmailAddress")
                        .IsRequired();

                    b.Property<string>("CityInstagramProfile")
                        .HasMaxLength(500);

                    b.Property<string>("DestinationName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("LocationId");

                    b.Property<bool>("OvernightStay");

                    b.HasKey("ID");

                    b.HasIndex("LocationId");

                    b.ToTable("Destination");
                });

            modelBuilder.Entity("CoreCrud.Models.Destination", b =>
                {
                    b.HasOne("CoreCrud.Models.Country", "Location")
                        .WithMany("Destinations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
