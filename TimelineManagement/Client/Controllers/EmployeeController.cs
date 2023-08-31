using Client.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TimelineManagement.Models;

namespace Client.Controllers
{
    [Authorize(Roles = "Project Manager")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _employeeRepository.Get();
            var ListEmployee = new List<Employee>();

            if (result.Data != null)
            {
                ListEmployee = result.Data.ToList();
            }
            return View(ListEmployee);
        }

        [HttpGet]
        public IActionResult MyProfile()
        {
            return View();
        }
    }
}
