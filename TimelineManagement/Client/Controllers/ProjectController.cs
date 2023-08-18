using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
