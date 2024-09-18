﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tour.of.dotnet.angular.heroes.Entities.Models;

#nullable disable

namespace tour.of.dotnet.angular.heroes.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20240911192501_SpellingChange")]
    partial class SpellingChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.33");

            modelBuilder.Entity("Hero", b =>
                {
                    b.Property<int>("HeroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PowerPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("HeroId");

                    b.HasIndex("TeamId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Superpower", b =>
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

            modelBuilder.Entity("Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PowerPoints")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Purpose")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Hero", b =>
                {
                    b.HasOne("Team", "Team")
                        .WithMany("Heroes")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Superpower", b =>
                {
                    b.HasOne("Hero", null)
                        .WithMany("SuperPowers")
                        .HasForeignKey("HeroId");
                });

            modelBuilder.Entity("Hero", b =>
                {
                    b.Navigation("SuperPowers");
                });

            modelBuilder.Entity("Team", b =>
                {
                    b.Navigation("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}
