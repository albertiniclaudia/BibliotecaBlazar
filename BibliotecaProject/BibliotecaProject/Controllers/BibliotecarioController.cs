using BibliotecaProject.Database;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaProject.Controllers
{
    public class BibliotecarioController : Controller
    {

        private readonly BibliotecaDbContext bibliotecaDbContext;

        public BibliotecarioController(BibliotecaDbContext bibliotecaDbContext)
        {
            this.bibliotecaDbContext = bibliotecaDbContext;
        }

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
