using System.Net;
using API.DataTransferObjects.AccountForVendors;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountForVendorController : ControllerBase
    {
        private readonly AccountForVendorService _accountForVendorService;

        public AccountForVendorController(AccountForVendorService accountForVendorService)
        {
            _accountForVendorService = accountForVendorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var accountForVendors = _accountForVendorService.Get();

            if (!accountForVendors.Any())
            {
                return NotFound(new ResponseHandler<AccountForVendorDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "No account for vendor found",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<IEnumerable<AccountForVendorDtoGet>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Account for vendor found",
                Data = accountForVendors
            });
        }

        [HttpGet("{guid}")]
        public IActionResult Get(Guid guid)
        {
            var accountForVendor = _accountForVendorService.Get(guid);

            if (accountForVendor is null)
            {
                return NotFound(new ResponseHandler<AccountForVendorDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Account for vendor not found",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<AccountForVendorDtoGet>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Account for vendor found",
                Data = accountForVendor
            });
        }

        [HttpPost]
        public IActionResult Create(AccountForVendorDtoCreate accountForVendorDtoCreate)
        {
            var vendorCreated = _accountForVendorService.Create(accountForVendorDtoCreate);

            if (vendorCreated is null)
            {
                return BadRequest(new ResponseHandler<AccountForVendorDtoCreate>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Account for vendor failed to create",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<AccountForVendorDtoCreate>
            {
                Code = StatusCodes.Status201Created,
                Status = HttpStatusCode.Created.ToString(),
                Message = "Account for vendor created",
                Data = vendorCreated
            });
        }

        [HttpPut("{guid}")]
        public IActionResult Update(AccountForVendorDtoUpdate accountForVendorDtoUpdate)
        {
            var employeeUpdated = _accountForVendorService.Update(accountForVendorDtoUpdate);

            if (employeeUpdated == -1)
            {
                return NotFound(new ResponseHandler<AccountForVendorDtoUpdate>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Account for vendor not found",
                    Data = null
                });
            }

            if (employeeUpdated == 0)
            {
                return BadRequest(new ResponseHandler<AccountForVendorDtoUpdate>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Account for vendor failed to update",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<AccountForVendorDtoUpdate>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Account for vendor updated",
                Data = accountForVendorDtoUpdate
            });
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var vendorDeleted = _accountForVendorService.Delete(guid);

            if (vendorDeleted == -1)
            {
                return NotFound(new ResponseHandler<AccountForVendorDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Account for vendor not found",
                    Data = null
                });
            }

            if (vendorDeleted == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountForVendorDtoGet>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Account for vendor failed to delete",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<AccountForVendorDtoGet>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Account for vendor deleted",
                Data = null
            });
        }

        [HttpPost("login")]
        public IActionResult Login(AccountLoginVendorDto accountLoginVendorDto)
        {
            var vendorLogin = _accountForVendorService.Login(accountLoginVendorDto);

            if (vendorLogin == "0")
            {
                return NotFound(new ResponseHandler<AccountForVendorDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Account for vendor not found",
                    Data = null
                });
            }

            if (vendorLogin == "-1")
            {
                return BadRequest(new ResponseHandler<AccountForVendorDtoGet>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Password is incorrect",
                    Data = null
                });
            }

            if (vendorLogin == "-2")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountForVendorDtoGet>
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
                Message = "Vendor successfully logged in",
                Data = vendorLogin
            });
        }

        [HttpPost("registerForVendor")]
        public IActionResult RegisterForVendor(AccountRegisterVendorDto accountRegisterVendorDto)
        {
            var isCreated = _accountForVendorService.Register(accountRegisterVendorDto);
            if (!isCreated)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountRegisterVendorDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Register failed"
                });
            }

            return Ok(new ResponseHandler<AccountRegisterVendorDto>
            {
                Code = StatusCodes.Status201Created,
                Status = HttpStatusCode.Created.ToString(),
                Message = "Register Success",
                Data = accountRegisterVendorDto
            });
        }
    }
}