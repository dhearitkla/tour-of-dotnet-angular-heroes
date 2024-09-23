﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tour.of.dotnet.angular.heroes.Entities.Models;

#nullable disable

namespace tour.of.dotnet.angular.heroes.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20240923143829_ManyToManyHeroSuperpower2")]
    partial class ManyToManyHeroSuperpower2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HeroSuperpower", b =>
                {
                    b.Property<Guid>("HeroesHeroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SuperpowersSuperpowerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HeroesHeroId", "SuperpowersSuperpowerId");

                    b.HasIndex("SuperpowersSuperpowerId");

                    b.ToTable("HeroSuperpower");
                });

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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuperpowerId");

                    b.ToTable("Superpowers");
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

            modelBuilder.Entity("HeroSuperpower", b =>
                {
                    b.HasOne("tour.of.dotnet.angular.heroes.Entities.Models.Hero", null)
                        .WithMany()
                        .HasForeignKey("HeroesHeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tour.of.dotnet.angular.heroes.Entities.Models.Superpower", null)
                        .WithMany()
                        .HasForeignKey("SuperpowersSuperpowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("tour.of.dotnet.angular.heroes.Entities.Models.Team", b =>
                {
                    b.Navigation("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}
