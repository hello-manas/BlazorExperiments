using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "error retrieving Data from the Database");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "error retrieving Data from the Database");
            }

        }
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                //var emp = employeeRepository.GetEmployeeByEmail(employee.Email);
                //if(emp!=null)
                //{
                //    ModelState.AddModelError("email", "Email already in use");
                //    return BadRequest(ModelState);
                //}
                var createdEmployee = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "error saving Data from the Database");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest("Employee ID mismatch");
                }

                var employeetoupdate = await employeeRepository.UpdateEmployee(employee);
                if (employeetoupdate == null)
                {
                    return NotFound($"Employee not found with employee ID {id}");
                }

                return employeetoupdate;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "error updating data");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var employeetodelete = await employeeRepository.GetEmployee(id);
                if (employeetodelete == null)
                {
                    return NotFound($"Employee not found with employee ID {id}");
                }

                return await employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "error deleting data");
            }

        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(String Name, Gender? gender)
        {
            try
            {
                var result = await employeeRepository.Search(Name, gender);
                if(result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "error searching data");
            }
            
            
        }
    }
}
