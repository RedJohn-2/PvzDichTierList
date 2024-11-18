﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MomBeatPvz.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MomBeatPvz.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241111191817_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.HeroEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Hero", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.HeroPriceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer");

                    b.Property<long>("SolutionId")
                        .HasColumnType("bigint");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.HasIndex("SolutionId");

                    b.ToTable("HeroPrice", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("MaxPrice")
                        .HasColumnType("integer");

                    b.Property<int>("MinPrice")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<long>("ResultId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ResultId");

                    b.ToTable("TierList", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListSolutionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<long?>("TierListId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TierListId");

                    b.ToTable("TierListSolution", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.HeroPriceEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.HeroEntity", "Hero")
                        .WithMany()
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomBeatPvz.Persistence.Entities.TierListSolutionEntity", "Solution")
                        .WithMany("Prices")
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.UserEntity", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomBeatPvz.Persistence.Entities.TierListSolutionEntity", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Result");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListSolutionEntity", b =>
                {
                    b.HasOne("MomBeatPvz.Persistence.Entities.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomBeatPvz.Persistence.Entities.TierListEntity", "TierList")
                        .WithMany("Solutions")
                        .HasForeignKey("TierListId");

                    b.Navigation("Owner");

                    b.Navigation("TierList");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListEntity", b =>
                {
                    b.Navigation("Solutions");
                });

            modelBuilder.Entity("MomBeatPvz.Persistence.Entities.TierListSolutionEntity", b =>
                {
                    b.Navigation("Prices");
                });
#pragma warning restore 612, 618
        }
    }
}
