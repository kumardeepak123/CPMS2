using CPMS.Models;
using CPMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _IEmployeeRepo;

        public EmployeeController(IEmployeeRepo  iEmployeeRepo)
        {
            _IEmployeeRepo = iEmployeeRepo;
        }

        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            var res = await _IEmployeeRepo.CreateEmployee(employee);
            if (!res)
            {
                return StatusCode(409); // a request conflict with the current state of the target resource.
            }

            return Ok(new { Message = "Employee created successfully" });
        }

        [HttpGet("employee/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var _Employee = await _IEmployeeRepo.GetEmployeeById(id);
            if (_Employee == null)
            {
                return NotFound();
            }

            return Ok(_Employee);
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var _Employees = await _IEmployeeRepo.GetAllEmployees();
            return Ok(_Employees);
        }

        [HttpPut("update-employee/{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody]Employee employee, int id)
        {
            var res = await _IEmployeeRepo.UpdateEmployee(id, employee);
            if (!res)
            {
                return BadRequest();
            }
            return Ok(new { Message = "Updated successfully" });
        }

        [HttpDelete("delete-employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var res = await _IEmployeeRepo.DeleteEmployee(id);
            if (!res)
            {
                return NotFound();
            }
            return Ok(new { Message = "Deleted successfully" });
        }

        [HttpGet("search-employee-designation")]
        public async Task<IActionResult> SearchEmployeeByDesignation(string designation)
        {
            var employees = await _IEmployeeRepo.SearchEmployeeByDesignationWithNoTeam(designation);
            
            return Ok(employees);
        }
    }
}
