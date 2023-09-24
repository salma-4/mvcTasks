﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvcD2.Models;

#nullable disable

namespace mvcD2.Migrations
{
    [DbContext(typeof(CompanyContext))]
    partial class CompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("mvcD2.Models.Emp_project", b =>
                {
                    b.Property<int>("emp_id")
                        .HasColumnType("int");

                    b.Property<int>("proj_id")
                        .HasColumnType("int");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<int?>("workingHours")
                        .HasColumnType("int");

                    b.HasKey("emp_id", "proj_id");

                    b.HasIndex("projectId");

                    b.ToTable("Emp_projects");
                });

            modelBuilder.Entity("mvcD2.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("office_id")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("office_id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("mvcD2.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("mvcD2.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("mvcD2.Models.Emp_project", b =>
                {
                    b.HasOne("mvcD2.Models.Employee", "Employee")
                        .WithMany("projects")
                        .HasForeignKey("emp_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mvcD2.Models.Project", "project")
                        .WithMany("Emp")
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("project");
                });

            modelBuilder.Entity("mvcD2.Models.Employee", b =>
                {
                    b.HasOne("mvcD2.Models.Office", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("office_id");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("mvcD2.Models.Employee", b =>
                {
                    b.Navigation("projects");
                });

            modelBuilder.Entity("mvcD2.Models.Office", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("mvcD2.Models.Project", b =>
                {
                    b.Navigation("Emp");
                });
#pragma warning restore 612, 618
        }
    }
}
