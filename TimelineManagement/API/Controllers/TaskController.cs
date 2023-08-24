using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimelineManagement.DTOs.Tasks;
using TimelineManagement.Services;
using TimelineManagement.Utilities.Handlers;

namespace TimelineManagement.Controllers;

[ApiController]
[Route("api/tasks")]
/*[Authorize(Roles = "Project Manager")]*/
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpGet("detail-task/{guid}")]
    public IActionResult GetDetailTaskByGuid(Guid guid)
    {
        var result = _taskService.GetDetailTaskByGuid(guid);
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<DetailTaskDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<DetailTaskDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }
    
    [Route("create-default")]
    [HttpPost]
    public IActionResult CreateDefault(NewDefaultTaskDto newDefaultTaskDto)
    {
        var result = _taskService.CreateDefault(newDefaultTaskDto);
        if(result is null)
        {
            return StatusCode(500, new ResponseHandler<NewDefaultTaskDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Create Task failed"
            });
        }
        return Ok(new ResponseHandler<NewDefaultTaskDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Create Task success",
            Data = result
        });
    }
    
    [HttpPut("change-status")]
    public IActionResult ChangeStatus(TaskChangeStatusDto taskChangeStatusDto)
    {
        var result = _taskService.ChangeStatus(taskChangeStatusDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<TaskChangeStatusDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<TaskChangeStatusDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskChangeStatusDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Change Employee success"
        });

    }
    
    [HttpPut("change-employee")]
    public IActionResult ChangeEmployee(TaskChangeEmployeeDto taskChangeEmployeeDto)
    {
        var result = _taskService.ChangeEmployee(taskChangeEmployeeDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<TaskChangeEmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<TaskChangeEmployeeDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskChangeEmployeeDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Change Employee success"
        });

    }
    
    [HttpPut("change-section")]
    public IActionResult ChangeSection(TaskChangeSection taskChangeSection)
    {
        var result = _taskService.ChangeSection(taskChangeSection);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<TaskChangeSection>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<TaskChangeSection>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskChangeSection>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Change Section success"
        });

    }
    
     [HttpGet]
    public IActionResult GetAll()
    {
        var result = _taskService.GetAll();
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<TaskDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<TaskDto>>
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
        var result = _taskService.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseHandler<TaskDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        return Ok(new ResponseHandler<TaskDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPost]
    public IActionResult Insert(NewTaskDto newTaskDto)
    {
        var result = _taskService.Create(newTaskDto);
        if (result is null)
        {
            return StatusCode(500, new ResponseHandler<TaskDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPut]
    public IActionResult Update(TaskDto TaskDto)
    {
        var result = _taskService.Update(TaskDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<TaskDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<TaskDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Update success"
        });

    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var result = _taskService.Delete(guid);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<TaskDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<TaskDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Delete success"
        });
    }
}