﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tour.of.dotnet.angular.heroes.Entities.Models;

#nullable disable

namespace tour.of.dotnet.angular.heroes.Migrations
{
    [DbContext(typeof(HeroContext))]
    partial class HeroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("tour.of.dotnet.angular.heroes.Entities.Models.Hero", b =>
                {
                    b.Property<Guid>("HeroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HeroId");

                    b.HasIndex("TeamId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("tour.of.dotnet.angular.heroes.Entities.Models.Superpower", b =>
                {
                    b.Property<Guid>("SuperpowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Classification")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<Guid?>("HeroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuperpowerId");

                    b.HasIndex("HeroId");

                    b.ToTable("SuperPowers");
                });

            modelBuilder.Entity("tour.of.dotnet.angular.heroes.Entities.Models.Team", b =>
                {
                    b.Property<Guid>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("tour.of.dotnet.angular.heroes.Entities.Models.Hero", b =>
                {
                    b.HasOne("tour.of.dotnet.angular.heroes.Entities.Models.Team", "Team")
                        .WithMany("Heroes")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("tour.of.dotnet.angular.heroes.Entities.Models.Superpower", b =>
                {
                    b.HasOne("tour.of.dotnet.angular.heroes.Entities.Models.Hero", null)
                        .WithMany("Superpowers")
                        .HasForeignKey("HeroId");
                });

            modelBuilder.Entity("tour.of.dotnet.angular.heroes.Entities.Models.Hero", b =>
                {
                    b.Navigation("Superpowers");
                });

            modelBuilder.Entity("tour.of.dotnet.angular.heroes.Entities.Models.Team", b =>
                {
                    b.Navigation("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}
