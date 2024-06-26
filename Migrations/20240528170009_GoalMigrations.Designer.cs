﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartFin.Db;

#nullable disable

namespace SmartFin.Migrations
{
    [DbContext(typeof(SmartFinDbContext))]
    [Migration("20240528170009_GoalMigrations")]
    partial class GoalMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmartFin.Entities.Category", b =>
                {
                    b.Property<Guid>("guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("factSumm")
                        .HasColumnType("numeric");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("planSumm")
                        .HasColumnType("numeric");

                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.HasKey("guid");

                    b.HasIndex("userId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SmartFin.Entities.Expense", b =>
                {
                    b.Property<Guid>("guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("dateOfExpense")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("sum")
                        .HasColumnType("numeric");

                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.HasKey("guid");

                    b.HasIndex("categoryId");

                    b.HasIndex("userId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("SmartFin.Entities.Goal", b =>
                {
                    b.Property<Guid>("guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("endOfPeriod")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("nameOfGoal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("payment")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("startOfPeriod")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("sum")
                        .HasColumnType("numeric");

                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.HasKey("guid");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("SmartFin.Entities.Recomendation", b =>
                {
                    b.Property<Guid>("guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("dateOfRecommendation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("goalId")
                        .HasColumnType("uuid");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.HasKey("guid");

                    b.HasIndex("goalId");

                    b.HasIndex("userId");

                    b.ToTable("Recomendations");
                });

            modelBuilder.Entity("SmartFin.Entities.User", b =>
                {
                    b.Property<Guid>("guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("goalId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("income")
                        .HasColumnType("numeric");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("guid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmartFin.Entities.Category", b =>
                {
                    b.HasOne("SmartFin.Entities.User", "user")
                        .WithMany("Categorys")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("SmartFin.Entities.Expense", b =>
                {
                    b.HasOne("SmartFin.Entities.Category", "category")
                        .WithMany("expenses")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartFin.Entities.User", "user")
                        .WithMany("Expenses")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("user");
                });

            modelBuilder.Entity("SmartFin.Entities.Goal", b =>
                {
                    b.HasOne("SmartFin.Entities.User", "user")
                        .WithOne("goal")
                        .HasForeignKey("SmartFin.Entities.Goal", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("SmartFin.Entities.Recomendation", b =>
                {
                    b.HasOne("SmartFin.Entities.Goal", "goal")
                        .WithMany("recomendations")
                        .HasForeignKey("goalId");

                    b.HasOne("SmartFin.Entities.User", "user")
                        .WithMany("Recomendations")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("goal");

                    b.Navigation("user");
                });

            modelBuilder.Entity("SmartFin.Entities.Category", b =>
                {
                    b.Navigation("expenses");
                });

            modelBuilder.Entity("SmartFin.Entities.Goal", b =>
                {
                    b.Navigation("recomendations");
                });

            modelBuilder.Entity("SmartFin.Entities.User", b =>
                {
                    b.Navigation("Categorys");

                    b.Navigation("Expenses");

                    b.Navigation("Recomendations");

                    b.Navigation("goal");
                });
#pragma warning restore 612, 618
        }
    }
}
