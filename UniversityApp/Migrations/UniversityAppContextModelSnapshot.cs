﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityApp.Data;

#nullable disable

namespace UniversityApp.Migrations
{
    [DbContext(typeof(UniversityAppContext))]
    partial class UniversityAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UnversityApp.Models.EnrollMent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdditionalPoints")
                        .HasColumnType("int");

                    b.Property<int>("ExamPoints")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("Pom1Id")
                        .HasColumnType("int");

                    b.Property<int>("Pom2Id")
                        .HasColumnType("int");

                    b.Property<int>("ProjectPoints")
                        .HasColumnType("int");

                    b.Property<string>("ProjectUrl")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("SeminalPoints")
                        .HasColumnType("int");

                    b.Property<string>("SeminalUrl")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Pom1Id");

                    b.HasIndex("Pom2Id");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("UnversityApp.Models.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AcquiredCredits")
                        .HasColumnType("int");

                    b.Property<int>("CurrentSemestar")
                        .HasColumnType("int");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("SubjectsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectsId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UnversityApp.Models.Subjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("FirstTeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Programme")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SecondTeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FirstTeacherId");

                    b.HasIndex("SecondTeacherId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("UnversityApp.Models.Teachers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AcademicRank")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OfficeNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("UnversityApp.Models.EnrollMent", b =>
                {
                    b.HasOne("UnversityApp.Models.Students", "Students")
                        .WithMany("EnrollMent")
                        .HasForeignKey("Pom1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnversityApp.Models.Subjects", "Subjects")
                        .WithMany("EnrollMent")
                        .HasForeignKey("Pom2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("UnversityApp.Models.Students", b =>
                {
                    b.HasOne("UnversityApp.Models.Subjects", null)
                        .WithMany("Studenti")
                        .HasForeignKey("SubjectsId");
                });

            modelBuilder.Entity("UnversityApp.Models.Subjects", b =>
                {
                    b.HasOne("UnversityApp.Models.Teachers", "Teachers1")
                        .WithMany("Subjects")
                        .HasForeignKey("FirstTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnversityApp.Models.Teachers", "Teachers2")
                        .WithMany("Subjects2")
                        .HasForeignKey("SecondTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teachers1");

                    b.Navigation("Teachers2");
                });

            modelBuilder.Entity("UnversityApp.Models.Students", b =>
                {
                    b.Navigation("EnrollMent");
                });

            modelBuilder.Entity("UnversityApp.Models.Subjects", b =>
                {
                    b.Navigation("EnrollMent");

                    b.Navigation("Studenti");
                });

            modelBuilder.Entity("UnversityApp.Models.Teachers", b =>
                {
                    b.Navigation("Subjects");

                    b.Navigation("Subjects2");
                });
#pragma warning restore 612, 618
        }
    }
}
