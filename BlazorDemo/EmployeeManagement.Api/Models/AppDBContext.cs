using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        //Seed Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Daepartments Table

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT"});
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admin" });

            //Seed Employees Table

            modelBuilder.Entity<Employee>().HasData(
                new Employee {

                    EmployeeId = 1,
                    FirstName = "Ram",
                    MiddleName = "",
                    LastName = "Sharma",
                    Email = "ramsharma@someemail.com",
                    DateOfBirth = new DateTime(1990, 10, 10),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/ram.png"

                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {

                    EmployeeId = 2,
                    FirstName = "Rahul",
                    MiddleName = "",
                    LastName = "Naik",
                    Email = "rahulnaik@someemail.com",
                    DateOfBirth = new DateTime(1990, 11, 14),
                    Gender = Gender.Male,
                    DepartmentId = 2,
                    PhotoPath = "images/rahul.png"

                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {

                    EmployeeId = 3,
                    FirstName = "Seema",
                    MiddleName = "",
                    LastName = "Dash",
                    Email = "SeemaDash@someemail.com",
                    DateOfBirth = new DateTime(1990, 11, 14),
                    Gender = Gender.Female,
                    DepartmentId = 2,
                    PhotoPath = "images/seema.png"

                });
        }
    }
}
