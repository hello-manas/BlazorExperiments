using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var result = await httpClient.GetJsonAsync<Department[]>("api/departments/");
            return result;
        }

        public async Task<Department> GetDepartment(int id)
        {
            var result = await httpClient.GetJsonAsync<Department>($"api/departments/{id}");
            return result;
        }

        
    }
}
