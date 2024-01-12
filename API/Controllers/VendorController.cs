using System.Net;
using System.Runtime.CompilerServices;
using API.DataTransferObjects.TenderProjects;
using API.Models;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly VendorService _vendorService;

        public VendorController(VendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var vendors = _vendorService.Get();
            if (!vendors.Any())
            {
                return NotFound(new ResponseHandler<VendorDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "No vendors found",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<IEnumerable<VendorDtoGet>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Vendors found",
                Data = vendors
            });

        }

        [HttpGet("{guid}")]
        public IActionResult Get(Guid guid)
        {
            var vendor = _vendorService.Get(guid);
            if (vendor is null)
            {
                return NotFound(new ResponseHandler<VendorDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Vendor not found",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<VendorDtoGet>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Vendor found",
                Data = vendor
            });
        }

        [HttpPost]
        public IActionResult Create(VendorDtoCreate vendorDtoCreate)
        {
            var vendorCreated = _vendorService.Create(vendorDtoCreate);
            if (vendorCreated is null)
            {
                return BadRequest(new ResponseHandler<VendorDtoCreate>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Vendor not created",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<VendorDtoCreate>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Vendor created",
                Data = vendorCreated
            });
        }

        [HttpPut]
        public IActionResult Update(VendorDtoUpdate vendorDtoUpdate)
        {
            var vendorUpdated = _vendorService.Update(vendorDtoUpdate);
            if (vendorUpdated == -1)
            {
                return NotFound(new ResponseHandler<VendorDtoUpdate>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Vendor not found",
                    Data = null
                });
            }

            if (vendorUpdated == 0)
            {
                return BadRequest(new ResponseHandler<VendorDtoUpdate>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Vendor not updated",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<VendorDtoUpdate>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Vendor updated",
                Data = vendorDtoUpdate
            });
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var vendorDeleted = _vendorService.Delete(guid);
            if (vendorDeleted == -1)
            {
                return NotFound(new ResponseHandler<VendorDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Vendor not found",
                    Data = null
                });
            }

            if (vendorDeleted == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<VendorDtoGet>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Vendor not deleted",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<VendorDtoGet>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Vendor deleted",
                Data = null
            });
        }

    }
}