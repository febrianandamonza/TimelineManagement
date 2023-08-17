using System.Net;
using Microsoft.AspNetCore.Mvc;
using TimelineManagement.DTOs.TaskComments;
using TimelineManagement.Services;
using TimelineManagement.Utilities.Handlers;

namespace TimelineManagement.Controllers;

[ApiController]
[Route("api/task-comments")]
public class TaskCommentController : ControllerBase
{
    private readonly TaskCommentService _taskCommentService;

    public TaskCommentController(TaskCommentService taskCommentService)
    {
        _taskCommentService = taskCommentService;
    }
    
     [HttpGet]
    public IActionResult GetAll()
    {
        var result = _taskCommentService.GetAll();
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<TaskCommentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<TaskCommentDto>>
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
        var result = _taskCommentService.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseHandler<TaskCommentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        return Ok(new ResponseHandler<TaskCommentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPost]
    public IActionResult Insert(NewTaskCommentDto newTaskCommentDto)
    {
        var result = _taskCommentService.Create(newTaskCommentDto);
        if (result is null)
        {
            return StatusCode(500, new ResponseHandler<TaskCommentDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskCommentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPut]
    public IActionResult Update(TaskCommentDto TaskCommentDto)
    {
        var result = _taskCommentService.Update(TaskCommentDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<TaskCommentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<TaskCommentDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskCommentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Update success"
        });

    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var result = _taskCommentService.Delete(guid);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<TaskCommentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<TaskCommentDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<TaskCommentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Delete success"
        });
    }
}