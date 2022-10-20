using Microsoft.AspNetCore.Mvc;

namespace BibliotecaProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult HomeAdmin()
        {
            return View();

        }
        public IActionResult AddAdmin()
        {
            return View();
        }

        public IActionResult AddLibrarian()
        {
            return View();
        }
    }
}
