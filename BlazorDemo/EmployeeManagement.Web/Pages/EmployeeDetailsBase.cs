using EmployeeManagement.Models;
using EmployeeManagement.Web.services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Inject]
        public IEmployeeService employeeservice { get; set; }
        public Employee employee { get; set; }
        [Parameter]
        public string Id { get; set; }

        public bool display { get; set; } = false;
        public string CssClass { get; set; } = null;
        public string displayfootertext { get; set; } = "HIDE FOOTER";
        protected override async Task OnInitializedAsync()
        {
            employee = await employeeservice.GetEmployee(int.Parse(Id));
            display = true;
        }

        protected void Button_Click()
        {
            if(displayfootertext == "SHOW FOOTER")
            {
                displayfootertext = "HIDE FOOTER";
                CssClass = null;
            }
            else if (displayfootertext == "HIDE FOOTER")
            {
                displayfootertext = "SHOW FOOTER";
                CssClass = "HideFooter";
            }
        }
    }
}
