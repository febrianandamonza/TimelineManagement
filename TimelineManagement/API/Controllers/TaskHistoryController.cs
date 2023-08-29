using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimelineManagement.DTOs.TaskComments;
using TimelineManagement.DTOs.TaskHistories;
using TimelineManagement.Services;
using TimelineManagement.Utilities.Handlers;

namespace TimelineManagement.Controllers;

[ApiController]
[Route("api/task-histories")]
[Authorize]
public class TaskHistoryController : ControllerBase
{
    private readonly TaskHistoryService _taskHistoryService;

    public TaskHistoryController(TaskHistoryService taskHistoryService)
    {
        _taskHistoryService = taskHistoryService;
    }
    [HttpGet("detail-task-histories-by-task/{projectGuid}/{taskGuid}")]
    public IActionResult GetDetailTaskByGuid(Guid projectGuid, Guid taskGuid)
    {
        var result = _taskHistoryService.DetailTaskHistory(taskGuid, projectGuid);
        if (result is null)
        {
            return NotFound(new ResponseHandler<DetailTaskHistoryDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<DetailTaskHistoryDto>>
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
        var result = _taskHistoryService.GetAll();
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<TaskHistoryDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<TaskHistoryDto>>
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
        var result = _taskHistoryService.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseHandler<TaskHistoryDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        return Ok(new ResponseHandler<TaskHistoryDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPost]
    public IActionResult Insert(NewTaskHistoryDto newTaskHistoryDto)
    {
        var result = _taskHistoryService.Create(newTaskHistoryDto);
        if (result is null)
        {
            return StatusCode(500, new ResponseHandler<TaskHistoryDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskHistoryDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPut]
    public IActionResult Update(TaskHistoryDto taskHistoryDto)
    {
        var result = _taskHistoryService.Update(taskHistoryDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<TaskHistoryDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<TaskHistoryDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskHistoryDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Update success"
        });

    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var result = _taskHistoryService.Delete(guid);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<TaskHistoryDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<TaskHistoryDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskHistoryDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Delete success"
        });
    }
}