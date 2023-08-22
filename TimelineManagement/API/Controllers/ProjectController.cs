using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TimelineManagement.DTOs.Projects;
using TimelineManagement.Services;
using TimelineManagement.Utilities.Handlers;

namespace TimelineManagement.Controllers;

[ApiController]
[Route("api/projects")]
//[Authorize(Roles = "Project Manager")]
[EnableCors]
public class ProjectController : ControllerBase
{
    private readonly ProjectService _projectService;

    public ProjectController(ProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [AllowAnonymous]
    [Route("create-default")]
    [HttpPost]
    public IActionResult CreateProject(NewDefaultProjectDto newDefaultProjectDto)
    {
        var result = _projectService.CreateProject(newDefaultProjectDto);
        if(result is null)
        {
            return StatusCode(500, new ResponseHandler<NewDefaultProjectDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Create Project failed"
            });
        }
        return Ok(new ResponseHandler<NewDefaultProjectDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Create Project success",
            Data = result
        });
    }

    [HttpGet("project-by-employee/{guid}")]
    public IActionResult GetAllByEmployeeGuid(Guid guid)
    {
        var result = _projectService.GetAllByEmployeeGuid(guid);
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<ProjectByEmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<ProjectByEmployeeDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _projectService.GetAll();
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<ProjectDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<ProjectDto>>
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
        var result = _projectService.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseHandler<ProjectDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        return Ok(new ResponseHandler<ProjectDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPost]
    public IActionResult Insert(NewProjectDto newProjectDto)
    {
        var result = _projectService.Create(newProjectDto);
        if (result is null)
        {
            return StatusCode(500, new ResponseHandler<ProjectDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<ProjectDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPut]
    public IActionResult Update(ProjectDto ProjectDto)
    {
        var result = _projectService.Update(ProjectDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<ProjectDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<ProjectDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<ProjectDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Update success"
        });

    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var result = _projectService.Delete(guid);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<ProjectDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<ProjectDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<ProjectDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Delete success"
        });
    }
}