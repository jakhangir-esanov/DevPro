﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagementSystem.DAL.Contexts;

#nullable disable

namespace ProjectManagementSystem.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectManagementSystem.Domain.Entities.Member", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("teamId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("teamId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Entities.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("teamId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("teamId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Entities.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("memberId")
                        .HasColumnType("bigint");

                    b.Property<long>("projectId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("memberId");

                    b.HasIndex("projectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Entities.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Entities.Member", b =>
                {
                    b.HasOne("ProjectManagementSystem.Domain.Entities.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("teamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Entities.Project", b =>
                {
                    b.HasOne("ProjectManagementSystem.Domain.Entities.Team", "Team")
                        .WithMany("Projects")
                        .HasForeignKey("teamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Entities.Task", b =>
                {
                    b.HasOne("ProjectManagementSystem.Domain.Entities.Member", "Member")
                        .WithMany("Tasks")
                        .HasForeignKey("memberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementSystem.Domain.Entities.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Entities.Member", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Entities.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Entities.Team", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
