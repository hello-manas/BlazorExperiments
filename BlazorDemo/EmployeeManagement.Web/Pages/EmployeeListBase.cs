using EmployeeManagement.Models;
using EmployeeManagement.Web.services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService employeeservice { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public bool display = false;
        public bool showfooter { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            Employees = (await employeeservice.GetEmployees()).ToList();
            display = true;
        }

        protected async Task EmployeeDeleted()
        {
            Employees = (await employeeservice.GetEmployees()).ToList();
        }
        

        //private void LoadEmployees()
        //{
        //    Employee e1 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "Ram",
        //        MiddleName = "",
        //        LastName = "Sharma",
        //        Email = "ramsharma@someemail.com",
        //        DateOfBirth = new DateTime(1990, 10, 10),
        //        Gender = Gender.Male,
        //        DepartmentId = 1,
        //        PhotoPath = "images/ram.png"
        //    };

        //    Employee e2 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "Rahul",
        //        MiddleName = "",
        //        LastName = "Naik",
        //        Email = "rahulnaik@someemail.com",
        //        DateOfBirth = new DateTime(1990, 11, 14),
        //        Gender = Gender.Male,
        //        DepartmentId = 2,
        //        PhotoPath = "images/rahul.png"
        //    };

        //    Employees = new List<Employee> {e1, e2 };
        //}
    }
}
