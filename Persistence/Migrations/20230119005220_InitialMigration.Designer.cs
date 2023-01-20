﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230119005220_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("DisciplineSpecialtyBase", b =>
                {
                    b.Property<int>("AllDisciplinesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BasedSpecialtiesId")
                        .HasColumnType("TEXT");

                    b.HasKey("AllDisciplinesId", "BasedSpecialtiesId");

                    b.HasIndex("BasedSpecialtiesId");

                    b.ToTable("DisciplineSpecialtyBase");
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Degree")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhotoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecialtyId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("UniversityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("PhotoId");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("UniversityId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.BachelorSpecialty", b =>
                {
                    b.Property<Guid>("SpecialtyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("TEXT");

                    b.HasKey("SpecialtyId", "UniversityId");

                    b.HasIndex("SpecialtyId")
                        .IsUnique();

                    b.HasIndex("UniversityId");

                    b.ToTable("BachelorSpecilaties");
                });

            modelBuilder.Entity("Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RegionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("UniversityId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Domain.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Discipline");
                });

            modelBuilder.Entity("Domain.ISCED", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ISCED");
                });

            modelBuilder.Entity("Domain.JunBachelorSpecialty", b =>
                {
                    b.Property<Guid>("SpecialtyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("TEXT");

                    b.HasKey("SpecialtyId", "UniversityId");

                    b.HasIndex("SpecialtyId")
                        .IsUnique();

                    b.HasIndex("UniversityId");

                    b.ToTable("JunBachelorSpecialties");
                });

            modelBuilder.Entity("Domain.MagisterSpecialty", b =>
                {
                    b.Property<Guid>("SpecialtyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("TEXT");

                    b.HasKey("SpecialtyId", "UniversityId");

                    b.HasIndex("SpecialtyId")
                        .IsUnique();

                    b.HasIndex("UniversityId");

                    b.ToTable("MagisterSpecialties");
                });

            modelBuilder.Entity("Domain.Photo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Domain.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("Domain.SelectedUniversity", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("TEXT");

                    b.HasKey("AppUserId", "UniversityId");

                    b.HasIndex("UniversityId");

                    b.ToTable("SelectedUniversities");
                });

            modelBuilder.Entity("Domain.Specialty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("BudgetAllowed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Degree")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("EctsCredits")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PriceUAH")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecialtyBaseId")
                        .HasColumnType("TEXT");

                    b.Property<int>("StartYear")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyBaseId");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("Domain.SpecialtyBase", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SpecialtyBases");
                });

            modelBuilder.Entity("Domain.SpecialtyDiscipline", b =>
                {
                    b.Property<Guid>("SpecialtyId")
                        .HasColumnType("TEXT");

                    b.Property<int>("DisciplineId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOptional")
                        .HasColumnType("INTEGER");

                    b.HasKey("SpecialtyId", "DisciplineId");

                    b.HasIndex("DisciplineId");

                    b.ToTable("SpecialtyDisciplines");
                });

            modelBuilder.Entity("Domain.University", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Info")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RegionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentsCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.Property<int>("TimesRated")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Website")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Domain.UniversityAdministrator", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("TEXT");

                    b.HasKey("AppUserId", "UniversityId");

                    b.HasIndex("UniversityId");

                    b.ToTable("UniversityAdministrators");
                });

            modelBuilder.Entity("ISCEDSpecialtyBase", b =>
                {
                    b.Property<string>("ISCEDsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecialtyBasesId")
                        .HasColumnType("TEXT");

                    b.HasKey("ISCEDsId", "SpecialtyBasesId");

                    b.HasIndex("SpecialtyBasesId");

                    b.ToTable("ISCEDSpecialtyBase");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

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
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DisciplineSpecialtyBase", b =>
                {
                    b.HasOne("Domain.Discipline", null)
                        .WithMany()
                        .HasForeignKey("AllDisciplinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.SpecialtyBase", null)
                        .WithMany()
                        .HasForeignKey("BasedSpecialtiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.HasOne("Domain.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");

                    b.HasOne("Domain.SpecialtyBase", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyId");

                    b.HasOne("Domain.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId");

                    b.Navigation("Photo");

                    b.Navigation("Specialty");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Domain.BachelorSpecialty", b =>
                {
                    b.HasOne("Domain.Specialty", "Specialty")
                        .WithOne("Bachelor")
                        .HasForeignKey("Domain.BachelorSpecialty", "SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.University", "University")
                        .WithMany("BachelorSpecialties")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Domain.City", b =>
                {
                    b.HasOne("Domain.Region", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.HasOne("Domain.AppUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Domain.University", "University")
                        .WithMany("Comments")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Author");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Domain.JunBachelorSpecialty", b =>
                {
                    b.HasOne("Domain.Specialty", "Specialty")
                        .WithOne("JunBachelor")
                        .HasForeignKey("Domain.JunBachelorSpecialty", "SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.University", "University")
                        .WithMany("JunBachelorSpecialties")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Domain.MagisterSpecialty", b =>
                {
                    b.HasOne("Domain.Specialty", "Specialty")
                        .WithOne("Magister")
                        .HasForeignKey("Domain.MagisterSpecialty", "SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.University", "University")
                        .WithMany("MagisterSpecialties")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Domain.SelectedUniversity", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("SelectedUniversities")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.University", "University")
                        .WithMany("AppUserSelected")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Domain.Specialty", b =>
                {
                    b.HasOne("Domain.SpecialtyBase", "SpecialtyBase")
                        .WithMany()
                        .HasForeignKey("SpecialtyBaseId");

                    b.Navigation("SpecialtyBase");
                });

            modelBuilder.Entity("Domain.SpecialtyDiscipline", b =>
                {
                    b.HasOne("Domain.Discipline", "Discipline")
                        .WithMany("Specialties")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Specialty", "Specialty")
                        .WithMany("Disciplines")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("Domain.University", b =>
                {
                    b.HasOne("Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.UniversityAdministrator", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("UniversityAdministration")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.University", "University")
                        .WithMany("UniversityAdministrators")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("University");
                });

            modelBuilder.Entity("ISCEDSpecialtyBase", b =>
                {
                    b.HasOne("Domain.ISCED", null)
                        .WithMany()
                        .HasForeignKey("ISCEDsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.SpecialtyBase", null)
                        .WithMany()
                        .HasForeignKey("SpecialtyBasesId")
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

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Navigation("SelectedUniversities");

                    b.Navigation("UniversityAdministration");
                });

            modelBuilder.Entity("Domain.Discipline", b =>
                {
                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("Domain.Region", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Domain.Specialty", b =>
                {
                    b.Navigation("Bachelor");

                    b.Navigation("Disciplines");

                    b.Navigation("JunBachelor");

                    b.Navigation("Magister");
                });

            modelBuilder.Entity("Domain.University", b =>
                {
                    b.Navigation("AppUserSelected");

                    b.Navigation("BachelorSpecialties");

                    b.Navigation("Comments");

                    b.Navigation("JunBachelorSpecialties");

                    b.Navigation("MagisterSpecialties");

                    b.Navigation("UniversityAdministrators");
                });
#pragma warning restore 612, 618
        }
    }
}