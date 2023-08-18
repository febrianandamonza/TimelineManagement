﻿using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimelineManagement.DTOs.Tasks;
using TimelineManagement.Services;
using TimelineManagement.Utilities.Handlers;

namespace TimelineManagement.Controllers;

[ApiController]
[Route("api/tasks")]
[Authorize(Roles = "Project Manager")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
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