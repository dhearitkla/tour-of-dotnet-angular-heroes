﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tour_of_dotnet_angular_heros.Entities.Models;

#nullable disable

namespace tour_of_dotnet_angular_heros.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20240911192930_IndividualClasses")]
    partial class IndividualClasses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.33");

            modelBuilder.Entity("tour_of_dotnet_angular_heros.Entities.Models.Hero", b =>
                {
                    b.Property<int>("HeroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("HeroId");

                    b.HasIndex("TeamId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("tour_of_dotnet_angular_heros.Entities.Models.Superpower", b =>
                {
                    b.Property<int>("SuperpowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Classification")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HeroId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("SuperpowerId");

                    b.HasIndex("HeroId");

                    b.ToTable("SuperPowers");
                });

            modelBuilder.Entity("tour_of_dotnet_angular_heros.Entities.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Purpose")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("tour_of_dotnet_angular_heros.Entities.Models.Hero", b =>
                {
                    b.HasOne("tour_of_dotnet_angular_heros.Entities.Models.Team", "Team")
                        .WithMany("Heroes")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("tour_of_dotnet_angular_heros.Entities.Models.Superpower", b =>
                {
                    b.HasOne("tour_of_dotnet_angular_heros.Entities.Models.Hero", null)
                        .WithMany("Superpowers")
                        .HasForeignKey("HeroId");
                });

            modelBuilder.Entity("tour_of_dotnet_angular_heros.Entities.Models.Hero", b =>
                {
                    b.Navigation("Superpowers");
                });

            modelBuilder.Entity("tour_of_dotnet_angular_heros.Entities.Models.Team", b =>
                {
                    b.Navigation("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}
