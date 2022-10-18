using Microsoft.AspNetCore.Mvc;

namespace BibliotecaProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserProfile()
        {
            return View();
        }
    }
}
