using Microsoft.AspNetCore.Mvc;

namespace BibliotecaProject.Controllers
{
    public class BibliotecarioController : Controller
    {
        public IActionResult Purchase()
        {
            return View();
        }
		public IActionResult HomeUser()
		{
			return View();

		}
	}
}
