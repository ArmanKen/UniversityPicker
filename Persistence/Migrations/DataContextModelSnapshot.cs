﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Accreditation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccreditationLevel")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accreditations");
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<int?>("CurrentStatusId")
                        .HasColumnType("integer");

                    b.Property<int?>("DegreeId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("FacultyId")
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<Guid?>("HigherEducationFacilityId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsGlobalAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("PhotoId")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("SpecialtyBaseId")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentStatusId");

                    b.HasIndex("DegreeId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("HigherEducationFacilityId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("PhotoId");

                    b.HasIndex("SpecialtyBaseId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("RegionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Domain.CurrentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CurrentStatuses");
                });

            modelBuilder.Entity("Domain.Degree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("Domain.EduComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EctsCredits")
                        .HasColumnType("integer");

                    b.Property<string>("Info")
                        .HasColumnType("text");

                    b.Property<bool>("IsOptional")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("SpecialtyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("EduComponents");
                });

            modelBuilder.Entity("Domain.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FacultyPhotoId")
                        .HasColumnType("text");

                    b.Property<Guid?>("HigherEducationFacilityId")
                        .HasColumnType("uuid");

                    b.Property<string>("Info")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("StudentsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FacultyPhotoId");

                    b.HasIndex("HigherEducationFacilityId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Domain.FavoriteList", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<Guid>("HigherEducationFacilityId")
                        .HasColumnType("uuid");

                    b.HasKey("AppUserId", "HigherEducationFacilityId");

                    b.HasIndex("HigherEducationFacilityId");

                    b.ToTable("FavoriteLists");
                });

            modelBuilder.Entity("Domain.HigherEducationFacility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("AccreditationId")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Info")
                        .HasColumnType("text");

                    b.Property<int?>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("RegionId")
                        .HasColumnType("integer");

                    b.Property<string>("Telephone")
                        .HasColumnType("text");

                    b.Property<string>("TitlePhoto")
                        .HasColumnType("text");

                    b.Property<int>("UkraineTop")
                        .HasColumnType("integer");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccreditationId");

                    b.HasIndex("CityId");

                    b.HasIndex("LocationId");

                    b.HasIndex("RegionId");

                    b.ToTable("HigherEducationFacilities");
                });

            modelBuilder.Entity("Domain.HigherEducationFacilityAdmin", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<Guid>("HigherEducationFacilityId")
                        .HasColumnType("uuid");

                    b.HasKey("AppUserId", "HigherEducationFacilityId");

                    b.HasIndex("HigherEducationFacilityId");

                    b.ToTable("HigherEducationFacilitiesAdmins");
                });

            modelBuilder.Entity("Domain.Isced", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Isceds");
                });

            modelBuilder.Entity("Domain.KnowledgeBranch", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("KnowledgeBranches");
                });

            modelBuilder.Entity("Domain.Language", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Domain.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Domain.Photo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<Guid?>("HigherEducationFacilityId")
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HigherEducationFacilityId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Domain.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorId")
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("HigherEducationFacilityId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("HigherEducationFacilityId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Domain.Specialty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("BudgetAllowed")
                        .HasColumnType("boolean");

                    b.Property<int?>("DegreeId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("EndYear")
                        .HasColumnType("integer");

                    b.Property<Guid?>("FacultyId")
                        .HasColumnType("uuid");

                    b.Property<int>("PriceUAH")
                        .HasColumnType("integer");

                    b.Property<string>("SpecialtyBaseId")
                        .HasColumnType("text");

                    b.Property<int>("StartYear")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DegreeId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("SpecialtyBaseId");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("Domain.SpecialtyBase", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("KnowledgeBranchId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("KnowledgeBranchId");

                    b.ToTable("SpecialtyBases");
                });

            modelBuilder.Entity("Domain.StudyForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Form")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StudyForms");
                });

            modelBuilder.Entity("FacultyKnowledgeBranch", b =>
                {
                    b.Property<Guid>("FacultiesId")
                        .HasColumnType("uuid");

                    b.Property<string>("KnowledgeBranchesId")
                        .HasColumnType("text");

                    b.HasKey("FacultiesId", "KnowledgeBranchesId");

                    b.HasIndex("KnowledgeBranchesId");

                    b.ToTable("FacultyKnowledgeBranch");
                });

            modelBuilder.Entity("IscedSpecialtyBase", b =>
                {
                    b.Property<string>("IscedsId")
                        .HasColumnType("text");

                    b.Property<string>("SpecialtyBasesId")
                        .HasColumnType("text");

                    b.HasKey("IscedsId", "SpecialtyBasesId");

                    b.HasIndex("SpecialtyBasesId");

                    b.ToTable("IscedSpecialtyBase");
                });

            modelBuilder.Entity("LanguageSpecialty", b =>
                {
                    b.Property<string>("LanguagesId")
                        .HasColumnType("text");

                    b.Property<Guid>("SpecialtiesId")
                        .HasColumnType("uuid");

                    b.HasKey("LanguagesId", "SpecialtiesId");

                    b.HasIndex("SpecialtiesId");

                    b.ToTable("LanguageSpecialty");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SpecialtyStudyForm", b =>
                {
                    b.Property<Guid>("SpecialtiesId")
                        .HasColumnType("uuid");

                    b.Property<int>("StudyFormsId")
                        .HasColumnType("integer");

                    b.HasKey("SpecialtiesId", "StudyFormsId");

                    b.HasIndex("StudyFormsId");

                    b.ToTable("SpecialtyStudyForm");
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.HasOne("Domain.CurrentStatus", "CurrentStatus")
                        .WithMany()
                        .HasForeignKey("CurrentStatusId");

                    b.HasOne("Domain.Degree", "Degree")
                        .WithMany()
                        .HasForeignKey("DegreeId");

                    b.HasOne("Domain.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");

                    b.HasOne("Domain.HigherEducationFacility", "HigherEducationFacility")
                        .WithMany()
                        .HasForeignKey("HigherEducationFacilityId");

                    b.HasOne("Domain.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");

                    b.HasOne("Domain.SpecialtyBase", "SpecialtyBase")
                        .WithMany()
                        .HasForeignKey("SpecialtyBaseId");

                    b.Navigation("CurrentStatus");

                    b.Navigation("Degree");

                    b.Navigation("Faculty");

                    b.Navigation("HigherEducationFacility");

                    b.Navigation("Photo");

                    b.Navigation("SpecialtyBase");
                });

            modelBuilder.Entity("Domain.City", b =>
                {
                    b.HasOne("Domain.Region", null)
                        .WithMany("Cities")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("Domain.EduComponent", b =>
                {
                    b.HasOne("Domain.Specialty", "Specialty")
                        .WithMany("EduComponents")
                        .HasForeignKey("SpecialtyId");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("Domain.Faculty", b =>
                {
                    b.HasOne("Domain.Photo", "FacultyPhoto")
                        .WithMany()
                        .HasForeignKey("FacultyPhotoId");

                    b.HasOne("Domain.HigherEducationFacility", "HigherEducationFacility")
                        .WithMany("Faculties")
                        .HasForeignKey("HigherEducationFacilityId");

                    b.Navigation("FacultyPhoto");

                    b.Navigation("HigherEducationFacility");
                });

            modelBuilder.Entity("Domain.FavoriteList", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("FavoriteList")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.HigherEducationFacility", "HigherEducationFacility")
                        .WithMany("FavoriteList")
                        .HasForeignKey("HigherEducationFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("HigherEducationFacility");
                });

            modelBuilder.Entity("Domain.HigherEducationFacility", b =>
                {
                    b.HasOne("Domain.Accreditation", "Accreditation")
                        .WithMany()
                        .HasForeignKey("AccreditationId");

                    b.HasOne("Domain.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.Navigation("Accreditation");

                    b.Navigation("City");

                    b.Navigation("Location");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.HigherEducationFacilityAdmin", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("HigherEducationFacilitiesAdmin")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.HigherEducationFacility", "HigherEducationFacility")
                        .WithMany("HigherEducationFacilityAdmins")
                        .HasForeignKey("HigherEducationFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("HigherEducationFacility");
                });

            modelBuilder.Entity("Domain.Photo", b =>
                {
                    b.HasOne("Domain.HigherEducationFacility", null)
                        .WithMany("Photos")
                        .HasForeignKey("HigherEducationFacilityId");
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.HasOne("Domain.AppUser", "Author")
                        .WithMany("Reviews")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Domain.HigherEducationFacility", "HigherEducationFacility")
                        .WithMany("Reviews")
                        .HasForeignKey("HigherEducationFacilityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Author");

                    b.Navigation("HigherEducationFacility");
                });

            modelBuilder.Entity("Domain.Specialty", b =>
                {
                    b.HasOne("Domain.Degree", "Degree")
                        .WithMany()
                        .HasForeignKey("DegreeId");

                    b.HasOne("Domain.Faculty", "Faculty")
                        .WithMany("Specialties")
                        .HasForeignKey("FacultyId");

                    b.HasOne("Domain.SpecialtyBase", "SpecialtyBase")
                        .WithMany("Specialties")
                        .HasForeignKey("SpecialtyBaseId");

                    b.Navigation("Degree");

                    b.Navigation("Faculty");

                    b.Navigation("SpecialtyBase");
                });

            modelBuilder.Entity("Domain.SpecialtyBase", b =>
                {
                    b.HasOne("Domain.KnowledgeBranch", "KnowledgeBranch")
                        .WithMany("SpecialtyBases")
                        .HasForeignKey("KnowledgeBranchId");

                    b.Navigation("KnowledgeBranch");
                });

            modelBuilder.Entity("FacultyKnowledgeBranch", b =>
                {
                    b.HasOne("Domain.Faculty", null)
                        .WithMany()
                        .HasForeignKey("FacultiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.KnowledgeBranch", null)
                        .WithMany()
                        .HasForeignKey("KnowledgeBranchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IscedSpecialtyBase", b =>
                {
                    b.HasOne("Domain.Isced", null)
                        .WithMany()
                        .HasForeignKey("IscedsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.SpecialtyBase", null)
                        .WithMany()
                        .HasForeignKey("SpecialtyBasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LanguageSpecialty", b =>
                {
                    b.HasOne("Domain.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Specialty", null)
                        .WithMany()
                        .HasForeignKey("SpecialtiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
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

                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpecialtyStudyForm", b =>
                {
                    b.HasOne("Domain.Specialty", null)
                        .WithMany()
                        .HasForeignKey("SpecialtiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.StudyForm", null)
                        .WithMany()
                        .HasForeignKey("StudyFormsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Navigation("FavoriteList");

                    b.Navigation("HigherEducationFacilitiesAdmin");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Domain.Faculty", b =>
                {
                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("Domain.HigherEducationFacility", b =>
                {
                    b.Navigation("Faculties");

                    b.Navigation("FavoriteList");

                    b.Navigation("HigherEducationFacilityAdmins");

                    b.Navigation("Photos");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Domain.KnowledgeBranch", b =>
                {
                    b.Navigation("SpecialtyBases");
                });

            modelBuilder.Entity("Domain.Region", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Domain.Specialty", b =>
                {
                    b.Navigation("EduComponents");
                });

            modelBuilder.Entity("Domain.SpecialtyBase", b =>
                {
                    b.Navigation("Specialties");
                });
#pragma warning restore 612, 618
        }
    }
}
