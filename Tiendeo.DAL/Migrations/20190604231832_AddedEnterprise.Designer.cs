﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tiendeo.DAL;

namespace Tiendeo.DAL.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190604231832_AddedEnterprise")]
    partial class AddedEnterprise
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tiendeo.DAL.Entities.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long?>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Tiendeo.DAL.Entities.Enterprise", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MarkerUrl")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Top");

                    b.HasKey("Id");

                    b.ToTable("Enterprise");
                });

            modelBuilder.Entity("Tiendeo.DAL.Entities.Establishment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<long>("CityId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Establishment");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Establishment");
                });

            modelBuilder.Entity("Tiendeo.DAL.Entities.Province", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("Tiendeo.DAL.Entities.Service", b =>
                {
                    b.HasBaseType("Tiendeo.DAL.Entities.Establishment");

                    b.Property<int>("ServiceType");

                    b.HasDiscriminator().HasValue("Service");
                });

            modelBuilder.Entity("Tiendeo.DAL.Entities.Store", b =>
                {
                    b.HasBaseType("Tiendeo.DAL.Entities.Establishment");

                    b.Property<long>("EnterpriseId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Top");

                    b.HasIndex("EnterpriseId");

                    b.HasDiscriminator().HasValue("Store");
                });

            modelBuilder.Entity("Tiendeo.DAL.Entities.City", b =>
                {
                    b.HasOne("Tiendeo.DAL.Entities.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("Tiendeo.DAL.Entities.Establishment", b =>
                {
                    b.HasOne("Tiendeo.DAL.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tiendeo.DAL.Entities.Store", b =>
                {
                    b.HasOne("Tiendeo.DAL.Entities.Enterprise", "Enterprise")
                        .WithMany()
                        .HasForeignKey("EnterpriseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
