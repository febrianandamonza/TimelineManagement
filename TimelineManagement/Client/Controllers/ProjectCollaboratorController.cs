using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using NuGet.Protocol.Core.Types;
using TimelineManagement.DTOs.Employees;
using TimelineManagement.DTOs.ProjectCollaborators;
using TimelineManagement.DTOs.Projects;
using TimelineManagement.Models;

namespace Client.Controllers
{
    [Authorize(Roles = "Project Manager")]
    public class ProjectCollaboratorController : Controller
    {
        private readonly IProjectCollaboratorRepository _projectCollaboratorRepository;

        public ProjectCollaboratorController(IProjectCollaboratorRepository repository)
        {
            _projectCollaboratorRepository = repository;
        }

        /*[HttpGet]
        public IActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewProjectByEmployeeDto newProjectByEmployeeDto)
        {
            var result = await _projectCollaboratorRepository.Create(newProjectByEmployeeDto);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction("Index", "Project");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _projectCollaboratorRepository.Get();
            var ListInvitation = new List<ProjectCollaborator>();

            if (result.Data != null)
            {
                ListInvitation = result.Data.ToList();
            }
            return View(ListInvitation);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _projectCollaboratorRepository.Get(id);
            var Invitation = new ProjectCollaborator();

            if (result.Data != null)
            {
                Invitation = result.Data;
            }
            return RedirectToAction("Index", "ProjectCollaborator");
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
