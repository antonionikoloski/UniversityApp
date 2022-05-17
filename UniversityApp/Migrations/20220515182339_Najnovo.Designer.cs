﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityApp.Data;

#nullable disable

namespace UniversityApp.Migrations
{
    [DbContext(typeof(UniversityAppContext))]
    [Migration("20220515182339_Najnovo")]
    partial class Najnovo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StudentsSubjects", b =>
                {
                    b.Property<int>("PredmetiId")
                        .HasColumnType("int");

                    b.Property<int>("StudentiId")
                        .HasColumnType("int");

                    b.HasKey("PredmetiId", "StudentiId");

                    b.HasIndex("StudentiId");

                    b.ToTable("StudentsSubjects");
                });

            modelBuilder.Entity("UniversityApp.Areas.Identity.Data.UniversityAppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

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

                    b.Property<int?>("TeachersId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Pom1Id");

                    b.HasIndex("Pom2Id");

                    b.HasIndex("TeachersId");

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

                    b.Property<int?>("TeachersId")
                        .HasColumnType("int");

                    b.Property<string>("id_foreignId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("nadvoresen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeachersId");

                    b.HasIndex("id_foreignId");

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

                    b.Property<int?>("TeachersId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FirstTeacherId");

                    b.HasIndex("TeachersId");

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

                    b.Property<string>("id_foreignId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("nadvoresen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("id_foreignId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("UniversityApp.Areas.Identity.Data.UniversityAppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("UniversityApp.Areas.Identity.Data.UniversityAppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityApp.Areas.Identity.Data.UniversityAppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("UniversityApp.Areas.Identity.Data.UniversityAppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentsSubjects", b =>
                {
                    b.HasOne("UnversityApp.Models.Subjects", null)
                        .WithMany()
                        .HasForeignKey("PredmetiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnversityApp.Models.Students", null)
                        .WithMany()
                        .HasForeignKey("StudentiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

                    b.HasOne("UnversityApp.Models.Teachers", null)
                        .WithMany("Enrollment")
                        .HasForeignKey("TeachersId");

                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("UnversityApp.Models.Students", b =>
                {
                    b.HasOne("UnversityApp.Models.Teachers", null)
                        .WithMany("Students")
                        .HasForeignKey("TeachersId");

                    b.HasOne("UniversityApp.Areas.Identity.Data.UniversityAppUser", "id_foreign")
                        .WithMany("Teachers")
                        .HasForeignKey("id_foreignId");

                    b.Navigation("id_foreign");
                });

            modelBuilder.Entity("UnversityApp.Models.Subjects", b =>
                {
                    b.HasOne("UnversityApp.Models.Teachers", "Teachers1")
                        .WithMany("Subjects")
                        .HasForeignKey("FirstTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnversityApp.Models.Teachers", null)
                        .WithMany("Subjects2")
                        .HasForeignKey("TeachersId");

                    b.Navigation("Teachers1");
                });

            modelBuilder.Entity("UnversityApp.Models.Teachers", b =>
                {
                    b.HasOne("UniversityApp.Areas.Identity.Data.UniversityAppUser", "id_foreign")
                        .WithMany("Subjects")
                        .HasForeignKey("id_foreignId");

                    b.Navigation("id_foreign");
                });

            modelBuilder.Entity("UniversityApp.Areas.Identity.Data.UniversityAppUser", b =>
                {
                    b.Navigation("Subjects");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("UnversityApp.Models.Students", b =>
                {
                    b.Navigation("EnrollMent");
                });

            modelBuilder.Entity("UnversityApp.Models.Subjects", b =>
                {
                    b.Navigation("EnrollMent");
                });

            modelBuilder.Entity("UnversityApp.Models.Teachers", b =>
                {
                    b.Navigation("Enrollment");

                    b.Navigation("Students");

                    b.Navigation("Subjects");

                    b.Navigation("Subjects2");
                });
#pragma warning restore 612, 618
        }
    }
}
