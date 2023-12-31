﻿using CukCuk.Core.Entities;
using CukCuk.Core.Exceptions;
using CukCuk.Core.Interfaces.Infrastructure;
using CukCuk.Core.Interfaces.Services;
using CukCuk.Core.Services;
using CukCuk.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CukCuk.Api.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        IEmployeeRepository _employeeRepository;
        IEmployeeService _employeeService;

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // Get data
            var employees = _employeeRepository.GetAll();

            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetById(Guid employeeId)
        {
            // Get data
            var employee = _employeeRepository.GetById(employeeId);

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult InsertEmployee(Employee employee)
        {
            try
            {
                // Validate
                employee.EmployeeId = Guid.NewGuid();
                _employeeService.InsertService(employee);

                return Created("", new { devMsg = "", userMsg = "Thêm tành công", data = employee });
            }
            catch (EmployeeValidException ex)
            {
                return BadRequest(new { devMsg = ex.Message, userMsg = ex.Message, data = employee });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { devMsg = ex.Message, userMsg = "Lỗi hệ thống", data = "" });
            }

        }

        [HttpPut("{employeeId}")]
        public IActionResult UpadteEmployee(Employee employee, Guid employeeId)
        {
            try
            {
                // Validate
                _employeeService.UpdateService(employeeId, employee);

                return Ok(new { devMsg = "", userMsg = "Cập nhật thành công", data = employee });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { devMsg = ex.Message, userMsg = "Lỗi hệ thống", data = "" });
            }
        }

        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(Guid employeeId)
        {
            try
            {
                var result = _employeeRepository.Delete(employeeId);
                return Ok(new { devMsg = "", userMsg = "Xóa thành công", data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { devMsg = ex.Message, userMsg = "Lỗi hệ thống", data = "" });
            }
        }
    }
}
