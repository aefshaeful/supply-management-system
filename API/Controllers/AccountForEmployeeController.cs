using System.Net;
using API.DataTransferObjects.AccountForEmployees;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountForEmployeeController : ControllerBase
    {
        private readonly AccountForEmployeeService _accountForEmployeeService;
        public AccountForEmployeeController(AccountForEmployeeService accountForEmployeeService)
        {
            _accountForEmployeeService = accountForEmployeeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var accountForEmployees = _accountForEmployeeService.Get();

            if (!accountForEmployees.Any())
            {
                return NotFound(new ResponseHandler<AccountForEmployeeDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "No account for employees found",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<IEnumerable<AccountForEmployeeDtoGet>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Account for employees found",
                Data = accountForEmployees
            });
        }

        [HttpGet("{guid}")]
        public IActionResult Get(Guid guid)
        {
            var accountForEmployee = _accountForEmployeeService.Get(guid);

            if (accountForEmployee is null)
            {
                return NotFound(new ResponseHandler<AccountForEmployeeDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Account for employee not found",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<AccountForEmployeeDtoGet>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Account for employee found",
                Data = accountForEmployee
            });
        }

        [HttpPost]
        public IActionResult Create(AccountForEmployeeDtoCreate accountForEmployeeDtoCreate)
        {
            var employeeCreated = _accountForEmployeeService.Create(accountForEmployeeDtoCreate);

            if (employeeCreated is null)
            {
                return BadRequest(new ResponseHandler<AccountForEmployeeDtoCreate>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Account for employee failed to create",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<AccountForEmployeeDtoCreate>
            {
                Code = StatusCodes.Status201Created,
                Status = HttpStatusCode.Created.ToString(),
                Message = "Account for employee successfully created",
                Data = employeeCreated
            });
        }

        [HttpPut("{guid}")]
        public IActionResult Update(AccountForEmployeeDtoUpdate accountForEmployeeDtoUpdate)
        {
            var employeeUpdated = _accountForEmployeeService.Update(accountForEmployeeDtoUpdate);

            if (employeeUpdated == -1)
            {
                return NotFound(new ResponseHandler<AccountForEmployeeDtoUpdate>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Account for employee not found",
                    Data = null
                });
            }

            if (employeeUpdated == 0)
            {
                return BadRequest(new ResponseHandler<AccountForEmployeeDtoUpdate>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Account for employee failed to update",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<AccountForEmployeeDtoUpdate>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Account for employee successfully updated",
                Data = accountForEmployeeDtoUpdate
            });
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var employeeDeleted = _accountForEmployeeService.Delete(guid);

            if (employeeDeleted == -1)
            {
                return NotFound(new ResponseHandler<AccountForEmployeeDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Account for employee not found",
                    Data = null
                });
            }

            if (employeeDeleted == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountForEmployeeDtoGet>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Account for employee failed to delete",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<AccountForEmployeeDtoGet>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Account for employee successfully deleted",
                Data = null
            });
        }

        [HttpPost("login")]
        public IActionResult login(AccountLoginEmployeeDto accountLoginEmployeeDto)
        {
            var employeeLogin = _accountForEmployeeService.Login(accountLoginEmployeeDto);

            if (employeeLogin == "0")
            {
                return NotFound(new ResponseHandler<AccountForEmployeeDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Account for employee not found",
                    Data = null
                });
            }

            if (employeeLogin == "-1")
            {
                return BadRequest(new ResponseHandler<AccountForEmployeeDtoGet>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Password is incorrect",
                    Data = null
                });
            }

            if (employeeLogin == "-2")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountForEmployeeDtoGet>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Error retrieving when creating token",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Employee successfully logged in",
                Data = employeeLogin
            });
        }


        [HttpPost("register")]
        public IActionResult Register(AccountRegisterEmployeeDto accountRegisterEmployeeDto)
        {
            var isCreated = _accountForEmployeeService.Register(accountRegisterEmployeeDto);
            if (!isCreated)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountRegisterEmployeeDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Register failed"
                });
            }

            return Ok(new ResponseHandler<AccountRegisterEmployeeDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Register Success"
            });
        }
    }
}