﻿using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int emplouyeeId);
        Task<Employee> GetEmployeeByEmail(string email);

        Task<Employee>  AddEmployee(Employee employee);
        Task<Employee>  UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int employeeid);
        Task<IEnumerable<Employee>> Search(string Name, Gender? gender);
    }
}
