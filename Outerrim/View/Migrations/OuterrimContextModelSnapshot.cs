﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

#nullable disable

namespace View.Migrations
{
    [DbContext(typeof(OuterrimContext))]
    partial class OuterrimContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("Model.Entities.Aircraft", b =>
                {
                    b.Property<int>("AircraftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Altitude")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fuel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecificationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Speed")
                        .HasColumnType("INTEGER");

                    b.HasKey("AircraftId");

                    b.HasIndex("SpecificationId");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("Model.Entities.AircraftCrew", b =>
                {
                    b.Property<int>("AircraftId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MercenaryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("AircraftId", "MercenaryId");

                    b.HasIndex("MercenaryId");

                    b.ToTable("AircraftCrewsJT");
                });

            modelBuilder.Entity("Model.Entities.AircraftSpecification", b =>
                {
                    b.Property<int>("SpecificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuelTankCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxAltitude")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxSpeed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinSpeed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpecificationCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Structure")
                        .HasColumnType("INTEGER");

                    b.HasKey("SpecificationId");

                    b.ToTable("AircraftSpecifications");
                });

            modelBuilder.Entity("Model.Entities.Compartment", b =>
                {
                    b.Property<int>("CompartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AircraftId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompartmentId");

                    b.HasIndex("AircraftId");

                    b.ToTable("Compartments");
                });

            modelBuilder.Entity("Model.Entities.CrimeSyndicate", b =>
                {
                    b.Property<int>("SyndicateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SyndicateId");

                    b.ToTable("CrimeSyndicates");
                });

            modelBuilder.Entity("Model.Entities.Machinery", b =>
                {
                    b.Property<int>("MachineryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.HasKey("MachineryId");

                    b.HasIndex("CompartmentId");

                    b.ToTable("Machineries");

                    b.HasDiscriminator<string>("Name").HasValue("Machinery");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Model.Entities.Mercenary", b =>
                {
                    b.Property<int>("MercenaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BodySkills")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CombatSkill")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MercenaryId");

                    b.ToTable("Mercenaries");
                });

            modelBuilder.Entity("Model.Entities.MercenaryReputation", b =>
                {
                    b.Property<int>("MercenaryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SyndicateId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReputationChange")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MercenaryId", "SyndicateId");

                    b.HasIndex("SyndicateId");

                    b.ToTable("MercenaryReputations");
                });

            modelBuilder.Entity("Model.Entities.EnergySystem", b =>
                {
                    b.HasBaseType("Model.Entities.Machinery");

                    b.ToTable("Machineries");

                    b.HasDiscriminator().HasValue("EnergySystems");
                });

            modelBuilder.Entity("Model.Entities.EnvironmentalSystem", b =>
                {
                    b.HasBaseType("Model.Entities.Machinery");

                    b.ToTable("Machineries");

                    b.HasDiscriminator().HasValue("EnvironmentalSystems");
                });

            modelBuilder.Entity("Model.Entities.Weapons", b =>
                {
                    b.HasBaseType("Model.Entities.Machinery");

                    b.ToTable("Machineries");

                    b.HasDiscriminator().HasValue("Weapons");
                });

            modelBuilder.Entity("Model.Entities.Aircraft", b =>
                {
                    b.HasOne("Model.Entities.AircraftSpecification", "Specification")
                        .WithMany("Aircrafts")
                        .HasForeignKey("SpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specification");
                });

            modelBuilder.Entity("Model.Entities.AircraftCrew", b =>
                {
                    b.HasOne("Model.Entities.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Mercenary", "Mercenary")
                        .WithMany()
                        .HasForeignKey("MercenaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");

                    b.Navigation("Mercenary");
                });

            modelBuilder.Entity("Model.Entities.Compartment", b =>
                {
                    b.HasOne("Model.Entities.Aircraft", "Aircraft")
                        .WithMany("Compartments")
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");
                });

            modelBuilder.Entity("Model.Entities.Machinery", b =>
                {
                    b.HasOne("Model.Entities.Compartment", "Compartment")
                        .WithMany("Machineries")
                        .HasForeignKey("CompartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compartment");
                });

            modelBuilder.Entity("Model.Entities.MercenaryReputation", b =>
                {
                    b.HasOne("Model.Entities.Mercenary", "Mercenary")
                        .WithMany()
                        .HasForeignKey("MercenaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.CrimeSyndicate", "Syndicate")
                        .WithMany()
                        .HasForeignKey("SyndicateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mercenary");

                    b.Navigation("Syndicate");
                });

            modelBuilder.Entity("Model.Entities.Aircraft", b =>
                {
                    b.Navigation("Compartments");
                });

            modelBuilder.Entity("Model.Entities.AircraftSpecification", b =>
                {
                    b.Navigation("Aircrafts");
                });

            modelBuilder.Entity("Model.Entities.Compartment", b =>
                {
                    b.Navigation("Machineries");
                });
#pragma warning restore 612, 618
        }
    }
}
