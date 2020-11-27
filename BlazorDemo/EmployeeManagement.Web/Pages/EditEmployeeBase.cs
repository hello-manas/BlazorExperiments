using EmployeeManagement.Models;
using EmployeeManagement.Web.services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IEmployeeService employeeservice { get; set; }
        [Inject]
        public IDepartmentService departmentService { get; set; }

        public Employee employee { get; set; } = new Employee();
        public List<Department> departments { get; set; } = new List<Department>();
        public string PageheaderText { get; set; }
        //public string  departmentid { get; set; }

        [Parameter]
        public string ID { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(ID, out int empid);
            if(empid != 0)
            {
                employee = await employeeservice.GetEmployee(int.Parse(ID));
                PageheaderText = "Edit Employee Details";
            }
            else
            {
                employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/noimage.png"
                };
                PageheaderText = "Add New Employee";
            }
            
            departments = (await departmentService.GetDepartments()).ToList();
            //departmentid = employee.Department.DepartmentId.ToString();
        }

        protected async Task HandleValidsubmit()
        {
            var result = new Employee();
            
            if(employee.EmployeeId !=0)
            {
                result = await employeeservice.UpdateEmployee(employee);
            }
            else
            {
                result = await employeeservice.CreateEmployee(employee);
            }
            
            if(result != null)
            {
                navigationManager.NavigateTo($"/employeedetails/{result.EmployeeId}");
            }
        }
        

        protected Global.Components.ConfirmComponentBase SaveConfirmation { get; set; }
        protected void Save_Click()
        {
            SaveConfirmation.show();
        }

        protected async Task ConfirmSave_Click(bool should_proceed)
        {
            if (should_proceed)
            {
                await HandleValidsubmit();
            }
        }

        //Delete confirmation

        public EventCallback<int> OnEmployeeDeleted { get; set; }

        protected Global.Components.ConfirmComponentBase DeleteConfirmation { get; set; }

       
        protected void Delete_Click()
        {
            DeleteConfirmation.show();
        }

        protected async Task ConfirmDelete_Click(bool shouldDelete)
        {
            if (shouldDelete)
            {
                await employeeservice.DeleteEmployee(employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(employee.EmployeeId);
                navigationManager.NavigateTo("/");
            }
        }
    }
}
