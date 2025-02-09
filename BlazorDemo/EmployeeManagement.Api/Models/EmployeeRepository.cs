﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext appDbContext;

        public EmployeeRepository(AppDBContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }       
        public async Task<Employee> AddEmployee(Employee employee)
        {
           var result = await appDbContext.Employees.AddAsync(employee);
           await appDbContext.SaveChangesAsync();
           return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeid)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeid);
            if(result!=null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int emplouyeeId)
        {
            return await appDbContext.Employees
                .Include(e=>e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == emplouyeeId);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string Name, Gender? gender)
        {
            IQueryable<Employee> query = appDbContext.Employees;
            if(!string.IsNullOrEmpty(Name))
            {
                query = query.Where(e => e.FirstName.Contains(Name) || e.LastName.Contains(Name));
            }
            if (gender != null)
            {
                query = query.Where(e => e.Gender==gender);
            }
            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.MiddleName = employee.MiddleName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();
                return result;

            }
            return null;
        }
    }
}
