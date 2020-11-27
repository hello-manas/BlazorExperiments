using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
   
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext appDbContext;

        public DepartmentRepository(AppDBContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Department> GetDepartment(int DepartmentId)
        {
            return await appDbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == DepartmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }
    }
}
