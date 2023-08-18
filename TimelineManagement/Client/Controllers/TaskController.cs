using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
