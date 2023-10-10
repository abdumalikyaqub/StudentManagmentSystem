﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudentManagmentSystem.Models;

#nullable disable

namespace StudentManagmentSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Dactyloscopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DateOfPassage")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Dactyloscopies");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("EducationBasisId")
                        .HasColumnType("integer");

                    b.Property<int?>("EducationFormId")
                        .HasColumnType("integer");

                    b.Property<int?>("EducationLevelId")
                        .HasColumnType("integer");

                    b.Property<string>("EntryYear")
                        .HasColumnType("text");

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.Property<int?>("InstituteId")
                        .HasColumnType("integer");

                    b.Property<string>("KursLevel")
                        .HasColumnType("text");

                    b.Property<int?>("SpecialityId")
                        .HasColumnType("integer");

                    b.Property<int?>("SpecializationId")
                        .HasColumnType("integer");

                    b.Property<int?>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.HasIndex("SpecialityId");

                    b.HasIndex("SpecializationId");

                    b.HasIndex("StudentId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Institute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryName")
                        .HasColumnType("text");

                    b.Property<string>("DistrictName")
                        .HasColumnType("text");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("text");

                    b.Property<string>("RegionName")
                        .HasColumnType("text");

                    b.Property<int?>("RoomNumber")
                        .HasColumnType("integer");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Birthday")
                        .HasColumnType("text");

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("integer");

                    b.Property<string>("FamilyStatus")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<int?>("GenderId")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PassportData")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Dactyloscopy", b =>
                {
                    b.HasOne("StudentManagmentSystem.Models.Entities.Student", "Student")
                        .WithMany("Dactyloscopies")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Education", b =>
                {
                    b.HasOne("StudentManagmentSystem.Models.Entities.Institute", "Institute")
                        .WithMany()
                        .HasForeignKey("InstituteId");

                    b.HasOne("StudentManagmentSystem.Models.Entities.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId");

                    b.HasOne("StudentManagmentSystem.Models.Entities.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId");

                    b.HasOne("StudentManagmentSystem.Models.Entities.Student", "Student")
                        .WithMany("Educations")
                        .HasForeignKey("StudentId");

                    b.Navigation("Institute");

                    b.Navigation("Speciality");

                    b.Navigation("Specialization");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Order", b =>
                {
                    b.HasOne("StudentManagmentSystem.Models.Entities.Student", "Student")
                        .WithMany("Orders")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Registration", b =>
                {
                    b.HasOne("StudentManagmentSystem.Models.Entities.Student", "Student")
                        .WithMany("Registrations")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Student", b =>
                {
                    b.HasOne("StudentManagmentSystem.Models.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("StudentManagmentSystem.Models.Entities.Student", b =>
                {
                    b.Navigation("Dactyloscopies");

                    b.Navigation("Educations");

                    b.Navigation("Orders");

                    b.Navigation("Registrations");
                });
#pragma warning restore 612, 618
        }
    }
}
