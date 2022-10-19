using BibliotecaProject.Database;
using BibliotecaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NuGet.Versioning;
//using System.Diagnostics;

namespace BibliotecaProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		public readonly BibliotecaDbContext bibliotecaDbContext;

		public HomeController(BibliotecaDbContext bibliotecaDbContext)
		{

			this.bibliotecaDbContext = bibliotecaDbContext;

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

        public IActionResult Noi()
        {
            return View();
        }
		public IActionResult CatalogoLibri()
		{
			return View();
		}

        public IActionResult DetailBook()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Index(string email, string password)
		{/*
			var user = bibliotecaDbContext.Users.Where(u => u.Email == email && u.Password == password);
			if(user.FirstOrDefault() != null)
			{
				if(user.FirstOrDefault().Role == "Admin")
				{
					return View("../Admin/HomeAdmin");
				}
				else if(user.FirstOrDefault().Role == "Librarian")
				{
					return View("../Bibliotecario/HomeLibrarian");
				}
				else
				{
					return View("../User/HomeUser");
				}
            return View();

        }

			}*/
			return View("../User/HomeUser");
			//return View("Index");
		}
    }
}