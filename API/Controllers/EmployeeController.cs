using System.Net;
using API.DataTransferObjects.Employees;
using API.Models;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeService.Get();
            if (!employees.Any())
            {
                return NotFound(new ResponseHandler<EmployeeDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "employees not found",
                });
            }

            return Ok(new ResponseHandler<IEnumerable<EmployeeDtoGet>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "employees found",
                Data = employees
            });
        }


        [HttpGet("{guid}")]
        public IActionResult Get(Guid guid)
        {
            var employee = _employeeService.Get(guid);
            if (employee is null)
            {
                return NotFound(new ResponseHandler<EmployeeDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "employee not found",
                });
            }

            return Ok(new ResponseHandler<EmployeeDtoGet>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "employee found",
                Data = employee
            });
        }

        [HttpPost]
        public IActionResult Create(EmployeeDtoCreate employeeDtoCreate)
        {
            var employeeCreated = _employeeService.Create(employeeDtoCreate);
            if (employeeCreated is null)
            {
                return BadRequest(new ResponseHandler<EmployeeDtoCreate>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "employee not created",
                });
            }

            return Ok(new ResponseHandler<EmployeeDtoCreate>
            {
                Code = StatusCodes.Status201Created,
                Status = HttpStatusCode.Created.ToString(),
                Message = "employee created",
                Data = employeeCreated
            });
        }

        [HttpPut]
        public IActionResult Update(EmployeeDtoUpdate employeeDtoUpdate)
        {
            var employeeUpdated = _employeeService.Update(employeeDtoUpdate);
            if (employeeUpdated == -1)
            {
                return NotFound(new ResponseHandler<EmployeeDtoUpdate>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "employee not found",
                });
            }

            if (employeeUpdated == 0)
            {
                return BadRequest(new ResponseHandler<EmployeeDtoUpdate>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "employee not updated",
                });
            }

            return Ok(new ResponseHandler<EmployeeDtoUpdate>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "employee updated",
                Data = employeeDtoUpdate
            });
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var employeeDeleted = _employeeService.Delete(guid);
            if (employeeDeleted == -1)
            {
                return NotFound(new ResponseHandler<EmployeeDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "employee not found",
                });
            }

            if (employeeDeleted == 0)
            {
                return BadRequest(new ResponseHandler<EmployeeDtoGet>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "employee not deleted",
                });
            }

            return Ok(new ResponseHandler<EmployeeDtoGet>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "employee successfully deleted",
            });
        }
    }
}