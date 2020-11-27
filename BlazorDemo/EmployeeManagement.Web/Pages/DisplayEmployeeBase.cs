using EmployeeManagement.Models;
using EmployeeManagement.Web.services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }

        [Inject]
        public IEmployeeService employeeservice { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        protected Global.Components.ConfirmComponentBase DeleteConfirmation { get; set; }
        protected void Delete_Click()
        {
            DeleteConfirmation.show();
        }

        protected async Task ConfirmDelete_Click(bool shouldDelete)
        {
            if(shouldDelete)
            {
                await employeeservice.DeleteEmployee(employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(employee.EmployeeId);
            }
        }

        

    }
}
