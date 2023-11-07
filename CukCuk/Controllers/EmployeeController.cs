using CukCuk.Core.Entities;
using CukCuk.Core.Exceptions;
using CukCuk.Core.Services;
using CukCuk.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CukCuk.Api.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            // Get data
            EmployeeRepository employeeRepository = new EmployeeRepository();
            var employees = employeeRepository.GetAll();

            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetById(Guid employeeId)
        {
            // Get data
            EmployeeRepository employeeRepository = new EmployeeRepository();
            var employee = employeeRepository.GetById(employeeId);

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult InsertEmployee(Employee employee)
        {
            try
            {
                // Validate
                EmployeeService employeeService = new EmployeeService();
                employeeService.InsertService(employee);

                // Insert data to DB
                EmployeeRepository employeeRepository = new EmployeeRepository();
                var result = employeeRepository.Insert(employee);

                return Ok(employee);
            }
            catch (EmployeeValidException ex)
            {
                return BadRequest(new { devMsg = ex.Message, userMsg = ex.Message, data = employee });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { devMsg = ex, userMsg = "Thêm thất bại", data = "" });
            }

        }

        [HttpPut]
        public IActionResult UpadteEmployee(Employee employee, Guid employeeId)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(Guid employeeId)
        {
            return Ok();
        }
    }
}
