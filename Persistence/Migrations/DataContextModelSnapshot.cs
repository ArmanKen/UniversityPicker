﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Domain.BranchOfKnowledge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BranchesOfKnowledge");
                });

            modelBuilder.Entity("Domain.BranchOfKnowledgeSpecialties", b =>
                {
                    b.Property<Guid>("BranchOfKnowledgeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SpecialtyId")
                        .HasColumnType("TEXT");

                    b.HasKey("BranchOfKnowledgeId", "SpecialtyId");

                    b.HasIndex("SpecialtyId")
                        .IsUnique();

                    b.ToTable("BranchOfKnowledgeSpecialties");
                });

            modelBuilder.Entity("Domain.Discipline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("Domain.Specialty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("Domain.SpecialtyDisciplines", b =>
                {
                    b.Property<Guid>("SpecialtyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("TEXT");

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

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.Property<string>("Website")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Domain.UniversityBranchesOfKnowledge", b =>
                {
                    b.Property<Guid>("UniversityId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BranchOfKnowledgeId")
                        .HasColumnType("TEXT");

                    b.HasKey("UniversityId", "BranchOfKnowledgeId");

                    b.HasIndex("BranchOfKnowledgeId")
                        .IsUnique();

                    b.ToTable("UniversityBranchesOfKnowledge");
                });

            modelBuilder.Entity("Domain.BranchOfKnowledgeSpecialties", b =>
                {
                    b.HasOne("Domain.BranchOfKnowledge", "BranchOfKnowledge")
                        .WithMany("Specialties")
                        .HasForeignKey("BranchOfKnowledgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Specialty", "Specialty")
                        .WithOne("BranchOfKnowledge")
                        .HasForeignKey("Domain.BranchOfKnowledgeSpecialties", "SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BranchOfKnowledge");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("Domain.SpecialtyDisciplines", b =>
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

            modelBuilder.Entity("Domain.UniversityBranchesOfKnowledge", b =>
                {
                    b.HasOne("Domain.BranchOfKnowledge", "BranchOfKnowledge")
                        .WithOne("University")
                        .HasForeignKey("Domain.UniversityBranchesOfKnowledge", "BranchOfKnowledgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.University", "University")
                        .WithMany("BranchesOfKnowledge")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BranchOfKnowledge");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Domain.BranchOfKnowledge", b =>
                {
                    b.Navigation("Specialties");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Domain.Discipline", b =>
                {
                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("Domain.Specialty", b =>
                {
                    b.Navigation("BranchOfKnowledge");

                    b.Navigation("Disciplines");
                });

            modelBuilder.Entity("Domain.University", b =>
                {
                    b.Navigation("BranchesOfKnowledge");
                });
#pragma warning restore 612, 618
        }
    }
}
