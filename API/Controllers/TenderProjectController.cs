using System.Net;
using API.DataTransferObjects.TenderProjects;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenderProjectController : ControllerBase
    {
        private readonly TenderProjectService _tenderProjectService;

        public TenderProjectController(TenderProjectService tenderProjectService)
        {
            _tenderProjectService = tenderProjectService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tenderProjects = _tenderProjectService.Get();
            if (!tenderProjects.Any())
            {
                return NotFound(new ResponseHandler<TenderProjectDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "No tender projects found",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<IEnumerable<TenderProjectDtoGet>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Tender projects found",
                Data = tenderProjects
            });
        }

        [HttpGet("{guid}")]
        public IActionResult Get(Guid guid)
        {
            var tenderProject = _tenderProjectService.Get(guid);
            if (tenderProject is null)
            {
                return NotFound(new ResponseHandler<TenderProjectDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Tender project not found",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<TenderProjectDtoGet>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Tender project found",
                Data = tenderProject
            });
        }

        [HttpPost]
        public IActionResult Create(TenderProjectDtoCreate tenderProjectDtoCreate)
        {
            var tenderProjectCreated = _tenderProjectService.Create(tenderProjectDtoCreate);
            if (tenderProjectCreated is null)
            {
                return BadRequest(new ResponseHandler<TenderProjectDtoCreate>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Tender project not created",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<TenderProjectDtoCreate>
            {
                Code = StatusCodes.Status201Created,
                Status = HttpStatusCode.Created.ToString(),
                Message = "Tender project created",
                Data = tenderProjectCreated
            });
        }

        [HttpPut]
        public IActionResult Update(TenderProjectDtoUpdate tenderProjectDtoUpdate)
        {
            var tenderProjectUpdated = _tenderProjectService.Update(tenderProjectDtoUpdate);
            if (tenderProjectUpdated == -1)
            {
                return NotFound(new ResponseHandler<TenderProjectDtoUpdate>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Tender project not found",
                    Data = null
                });
            }

            if (tenderProjectUpdated == 0)
            {
                return BadRequest(new ResponseHandler<TenderProjectDtoUpdate>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Tender project not updated",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<TenderProjectDtoUpdate>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Tender project updated",
                Data = tenderProjectDtoUpdate
            });
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var tenderProjectDeleted = _tenderProjectService.Delete(guid);
            if (tenderProjectDeleted == -1)
            {
                return NotFound(new ResponseHandler<TenderProjectDtoGet>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Tender project not found",
                    Data = null
                });
            }

            if (tenderProjectDeleted == 0)
            {
                return BadRequest(new ResponseHandler<TenderProjectDtoGet>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Tender project not deleted",
                    Data = null
                });
            }

            return Ok(new ResponseHandler<TenderProjectDtoGet>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Tender project deleted",
                Data = null
            });
        }
    }
}