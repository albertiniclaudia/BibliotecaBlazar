using BibliotecaProject.Database;
using BibliotecaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BibliotecaProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Biblio()
        {
            return View();
        }

        public IActionResult Contattaci()
        {
            return View();
        }

        public IActionResult Noi()
        {
            return View();
        }
        public IActionResult CatalogoLibri()
        {
            return View();

        }
		public IActionResult HomeLibrarian()
		{
			return View();

		}
		public IActionResult HomeUser()
		{
			return View();

		}
		public IActionResult HomeAdmin()
		{
			return View();

		}

        public IActionResult DetailBook()
        {
            return View();

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}