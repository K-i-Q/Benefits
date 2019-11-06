using Microsoft.AspNetCore.Mvc;

namespace Benefits.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        
    }
}