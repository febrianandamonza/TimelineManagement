using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimelineManagement.DTOs.ProjectCollaborators;
using TimelineManagement.Services;
using TimelineManagement.Utilities.Handlers;

namespace TimelineManagement.Controllers;

[ApiController]
[Route("api/project-collaborators")]
/*[Authorize(Roles = "Project Manager")]*/
public class ProjectCollaboratorController : ControllerBase
{
    private readonly ProjectCollaboratorService _projectCollaboratorService;

    public ProjectCollaboratorController(ProjectCollaboratorService projectCollaboratorService)
    {
        _projectCollaboratorService = projectCollaboratorService;
    }
    
    [HttpGet("count-project-by-employee/{guid}")]
    public IActionResult GetAllEmployeeDetail(Guid guid)
    {
        var result = _projectCollaboratorService.CountProjectByEmployee(guid);
        if (result is null)
        {
            return NotFound(new ResponseHandler<CountProjectByEmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<CountProjectByEmployeeDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }
    
    [HttpGet("waiting-by-employee/{guid}")]
    public IActionResult GetAllProjectCollaboratorWaitingByEmployee(Guid guid)
    {
        var result = _projectCollaboratorService.GetAllProjectCollaboratorIsWaitingByEmployee(guid);
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<ProjectCollaboratorWaitingDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<ProjectCollaboratorWaitingDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }
    
    [HttpGet("all-by-employee/{guid}")]
    public IActionResult GetAllProjectCollaboratorByEmployee(Guid guid)
    {
        var result = _projectCollaboratorService.GetAllProjectCollaboratorByEmployee(guid);
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<ProjectCollaboratorByEmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<ProjectCollaboratorByEmployeeDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPost("create-by-email")]
    public IActionResult CreateByEmployeeEmail(NewProjectByEmployeeDto newProjectByEmployeeDto)
    {
        var result = _projectCollaboratorService.CreateByEmail(newProjectByEmployeeDto);
        if (result is null)
        {
            return StatusCode(500, new ResponseHandler<NewProjectByEmployeeDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<NewProjectByEmployeeDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }
    
    [HttpPut("change-status")]
    public IActionResult ChangeStatus(ChangeStatusDto changeStatusDto)
    {
        var result = _projectCollaboratorService.ChangeStatus(changeStatusDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<ChangeStatusDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<ChangeStatusDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }
        return Ok(new ResponseHandler<ChangeStatusDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Update success"
        });
        
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _projectCollaboratorService.GetAll();
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<ProjectCollaboratorDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<ProjectCollaboratorDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _projectCollaboratorService.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseHandler<ProjectCollaboratorDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        return Ok(new ResponseHandler<ProjectCollaboratorDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPost]
    public IActionResult Insert(NewProjectCollaboratorDto newProjectCollaboratorDto)
    {
        var result = _projectCollaboratorService.Create(newProjectCollaboratorDto);
        if (result is null)
        {
            return StatusCode(500, new ResponseHandler<ProjectCollaboratorDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<ProjectCollaboratorDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPut]
    public IActionResult Update(ProjectCollaboratorDto ProjectCollaboratorDto)
    {
        var result = _projectCollaboratorService.Update(ProjectCollaboratorDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<ProjectCollaboratorDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<ProjectCollaboratorDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<ProjectCollaboratorDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Update success"
        });

    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var result = _projectCollaboratorService.Delete(guid);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<ProjectCollaboratorDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<ProjectCollaboratorDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<ProjectCollaboratorDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Delete success"
        });
    }
}