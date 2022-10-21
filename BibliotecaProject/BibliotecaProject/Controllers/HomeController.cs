using BibliotecaProject.Database;
using BibliotecaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NuGet.Versioning;
using System.Net.Mail;
using System.Net;
//using System.Diagnostics;
namespace BibliotecaProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		public readonly BibliotecaDbContext bibliotecaDbContext;
		private readonly IHttpContextAccessor _http;

		public HomeController(BibliotecaDbContext bibliotecaDbContext, IHttpContextAccessor httpContextAccessor)
		{

			this.bibliotecaDbContext = bibliotecaDbContext;
			_http = httpContextAccessor;
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

			var query = from b in bibliotecaDbContext.Books
						select b;

			return View(query);
		}

		public IActionResult HomeAdmin()
		{
			return View();
		}

		public IActionResult DetailBook()
        {
            return View();
        }

		public IActionResult RecuperoPassword()
		{
			return View();
		}

		[HttpPost]
		public IActionResult RecuperoPassword(string email)
		{
			var client = new SmtpClient("smtp.mailtrap.io", 2525)
			{
				Credentials = new NetworkCredential("6ab5386842dbc6", "9654bdaac28c9a"),
				EnableSsl = true
			};
			client.Send("RecuperoEmail@Biblioteca.com", email, "Hello world", "testbody");
			return View("Index");
		}
		[HttpPost]
		public IActionResult Index(string email, string password)
		{
			
			_http.HttpContext.Session.SetString("email", email);
			var user = bibliotecaDbContext.Users.Where(u => u.Email == email && u.Password == password);
			if(user.FirstOrDefault() != null)
			{
				if(user.FirstOrDefault().Role == "Admin")
				{
					_http.HttpContext.Session.SetString("role", "Admin");
					return View("../Admin/HomeAdmin");
				}
				else if(user.FirstOrDefault().Role == "Librarian")
				{
					_http.HttpContext.Session.SetString("role", "Librarian");
					return View("../Bibliotecario/HomeLibrarian");
				}
				else
				{
					_http.HttpContext.Session.SetString("name", user.FirstOrDefault().Name);
					_http.HttpContext.Session.SetString("role", "User");
					return View("../User/HomeUser");
				}
			}
			return View("Index");/*
			_http.HttpContext.Session.SetString("email", email);
			_http.HttpContext.Session.SetString("name", "Luca");
			_http.HttpContext.Session.SetString("role", "Admin");*/
			return View("../User/HomeUser");
		}
    }
}