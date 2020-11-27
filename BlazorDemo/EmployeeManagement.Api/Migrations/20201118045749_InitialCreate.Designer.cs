﻿// <auto-generated />
using System;
using EmployeeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Api.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20201118045749_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EmployeeManagement.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "IT"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "HR"
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentName = "Payroll"
                        },
                        new
                        {
                            DepartmentId = 4,
                            DepartmentName = "Admin"
                        });
                });

            modelBuilder.Entity("EmployeeManagement.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            DateOfBirth = new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Email = "ramsharma@someemail.com",
                            FirstName = "Ram",
                            Gender = 0,
                            LastName = "Sharma",
                            MiddleName = "",
                            PhotoPath = "images/ram.png"
                        },
                        new
                        {
                            EmployeeId = 2,
                            DateOfBirth = new DateTime(1990, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            Email = "rahulnaik@someemail.com",
                            FirstName = "Rahul",
                            Gender = 0,
                            LastName = "Naik",
                            MiddleName = "",
                            PhotoPath = "images/rahul.png"
                        },
                        new
                        {
                            EmployeeId = 3,
                            DateOfBirth = new DateTime(1990, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            Email = "SeemaDash@someemail.com",
                            FirstName = "Seema",
                            Gender = 1,
                            LastName = "Dash",
                            MiddleName = "",
                            PhotoPath = "images/seema.png"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
