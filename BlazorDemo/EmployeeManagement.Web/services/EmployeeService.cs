using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var result = await httpClient.GetJsonAsync<Employee[]>("api/employees/");
            return result;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var result = await httpClient.GetJsonAsync<Employee>($"api/employees/{id}");
            return result;
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            var result = await httpClient.PutJsonAsync<Employee>($"api/employees/{updatedEmployee.EmployeeId}", updatedEmployee);
            return result;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            var result = await httpClient.PostJsonAsync<Employee>($"api/employees/", newEmployee);
            return result;
        }

        public async Task DeleteEmployee(int ID)
        {
            var result = await httpClient.DeleteAsync($"api/employees/{ID}");
           
        }
    }
}
