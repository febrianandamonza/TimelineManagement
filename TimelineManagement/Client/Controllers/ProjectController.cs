﻿using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using NuGet.Protocol.Core.Types;
using TimelineManagement.DTOs.Employees;
using TimelineManagement.DTOs.Projects;
using TimelineManagement.Models;

namespace Client.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository repository)
        {
            _projectRepository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewDefaultProjectDto newDefaultProjectDto)
        {
            var result = await _projectRepository.Create(newDefaultProjectDto);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction("Index", "Home"); 
            }
            return View();
        }
        
        


        /*[HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _projectRepository.Get();
            var ListProject = new List<Project>();

            if (result.Data != null)
            {
                ListProject = result.Data.ToList();
            }
            return View(ListProject);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _projectRepository.Get(id);
            var ListProject = new Project();

            if (result.Data != null)
            {
                ListProject = result.Data;
            }
            return View(ListProject);
        }*/

        /*
        [HttpPost]
        public async Task<IActionResult> Update(ProjectDto projectDto)
        {
            var result = await _projectRepository.Put(projectDto.Guid, projectDto);

            if (result.Code == 200)
            {
                TempData["Success"] = $"Data has been Successfully Registered! - {result.Message}!";
                return RedirectToAction("Index", "Employee");
            }
            return RedirectToAction(nameof(Update));
        }
        */

        /*[HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _projectRepository.Get(id);
            var ListProject = new Project();
            if (result.Data != null)
            {
                ListProject = result.Data;
            }
            return View(ListProject);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _projectRepository.Delete(id);
            if (result.Code == 200)
            {
                TempData["Success"] = $"Data has been Successfully Registered! - {result.Message}!";
                return RedirectToAction("index", "employee");
            }
            return RedirectToAction(nameof(Index));
        }*/
    }
}
