using Client.Contracts;
using Microsoft.AspNetCore.Mvc;
using TimelineManagement.DTOs.ProjectCollaborators;
using TimelineManagement.DTOs.Tasks;

namespace Client.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository repository)
        {
            _taskRepository = repository;
        }
        // public IActionResult Index()
        // {
        //     return View();
        // }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewDefaultTaskDto newDefaultTaskDto)
        {
            var result = await _taskRepository.Create(newDefaultTaskDto);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction("Index", "Project");
            }
            return View();
        }
    }
}
