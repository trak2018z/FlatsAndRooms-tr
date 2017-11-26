﻿// <auto-generated />
using FlatAndRooms.Models;
using FlatAndRooms.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FlatsAndRooms.Migrations
{
    [DbContext(typeof(FlatAndRoomsContext))]
    [Migration("20171121230643_AddForeignKeysToAllEntities")]
    partial class AddForeignKeysToAllEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlatAndRooms.Models.Equipment", b =>
                {
                    b.Property<Guid>("EquipmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EquipmentName");

                    b.HasKey("EquipmentId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("FlatAndRooms.Models.EquipmentObjectToRent", b =>
                {
                    b.Property<Guid>("EquipmentObjectToRentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EquipmentDescription");

                    b.Property<Guid>("EquipmentId");

                    b.Property<Guid>("ObjectToRentId");

                    b.HasKey("EquipmentObjectToRentId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("ObjectToRentId");

                    b.ToTable("EquipmentObjectToRents");
                });

            modelBuilder.Entity("FlatAndRooms.Models.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("FlatAndRooms.Models.ObjectToRent", b =>
                {
                    b.Property<Guid>("ObjectToRentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("Floor");

                    b.Property<Guid?>("LocationId");

                    b.Property<int>("RoomsNumber");

                    b.Property<int>("Type");

                    b.Property<Guid?>("UserId");

                    b.HasKey("ObjectToRentId");

                    b.HasIndex("LocationId")
                        .IsUnique()
                        .HasFilter("[LocationId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("ObjectToRents");
                });

            modelBuilder.Entity("FlatAndRooms.Models.ObjectToRentPreference", b =>
                {
                    b.Property<Guid>("ObjectToRentPreferenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ObjectToRentId");

                    b.Property<string>("PreferenceDescription");

                    b.HasKey("ObjectToRentPreferenceId");

                    b.HasIndex("ObjectToRentId");

                    b.ToTable("ObjectToRentPreferences");
                });

            modelBuilder.Entity("FlatAndRooms.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EMail");

                    b.Property<string>("NickName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlatAndRooms.Models.UserPreference", b =>
                {
                    b.Property<Guid>("UserPreferenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ObjectToRentId");

                    b.Property<string>("PreferenceDescription");

                    b.Property<Guid>("UserId");

                    b.HasKey("UserPreferenceId");

                    b.HasIndex("ObjectToRentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPreference");
                });

            modelBuilder.Entity("FlatAndRooms.Models.EquipmentObjectToRent", b =>
                {
                    b.HasOne("FlatAndRooms.Models.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FlatAndRooms.Models.ObjectToRent", "ObjectToRent")
                        .WithMany()
                        .HasForeignKey("ObjectToRentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlatAndRooms.Models.ObjectToRent", b =>
                {
                    b.HasOne("FlatAndRooms.Models.Location", "Location")
                        .WithOne("ObjectToRent")
                        .HasForeignKey("FlatAndRooms.Models.ObjectToRent", "LocationId");

                    b.HasOne("FlatAndRooms.Models.User", "User")
                        .WithMany("ObjectsToRent")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FlatAndRooms.Models.ObjectToRentPreference", b =>
                {
                    b.HasOne("FlatAndRooms.Models.ObjectToRent", "ObjectToRent")
                        .WithMany()
                        .HasForeignKey("ObjectToRentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlatAndRooms.Models.UserPreference", b =>
                {
                    b.HasOne("FlatAndRooms.Models.ObjectToRent")
                        .WithMany("UserPreference")
                        .HasForeignKey("ObjectToRentId");

                    b.HasOne("FlatAndRooms.Models.User", "User")
                        .WithMany("UserPreference")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}