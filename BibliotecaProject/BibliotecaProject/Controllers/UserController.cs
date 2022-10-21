using BibliotecaProject.Database;
using BibliotecaProject.Models;
using BibliotecaProject.Database;
using Microsoft.AspNetCore.Mvc;
using BibliotecaProject.Models;
using static System.Net.WebRequestMethods;

namespace BibliotecaProject.Controllers
{
    public class UserController : Controller
    {
       
		private readonly ILogger<UserController> _logger;
		public readonly BibliotecaDbContext bibliotecaDbContext;
		private readonly IHttpContextAccessor _http;
		public UserController(BibliotecaDbContext bibliotecaDbContext)
		{
			this.bibliotecaDbContext = bibliotecaDbContext;
		}
		public IActionResult UserProfile()
        {
			UserModel model = new UserModel();
			model.user = bibliotecaDbContext.Users.Where(u => u.Email == _http.HttpContext.Session.GetString("email")).FirstOrDefault();
			model.getLoanData = (from l in bibliotecaDbContext.Loans
								 from u in bibliotecaDbContext.Users
								 where l.ID_user == u.Id
								 select l).ToList();
			return View(model);
        }
		public IActionResult Contattaci()
		{
			return View();
		}
		public IActionResult HomeUser()
		{
			return View();
		}
		public IActionResult RequestBook()
		{
			return View();
		}
		public IActionResult RecuperoPassword()
		{
			return View();
		}

		[HttpPost]
		public IActionResult RequestBook(string Title, string Author, string PublishingHouse, string ISBN)
		{
			var query = bibliotecaDbContext.Users.Where(u => u.Email == _http.HttpContext.Session.GetString("email"));
			PurchaseQueue pq = new PurchaseQueue
			{
				Title = Title,
				Author = Author,
				PublishingHouse = PublishingHouse,
				ISBN = ISBN,
				ID_user = query.FirstOrDefault().Id
			};
			bibliotecaDbContext.Add(pq);
			bibliotecaDbContext.SaveChanges();
			return View(pq);
        }
        public IActionResult dashboardUser()
        {
            IndexModel model = new IndexModel();


            model.getLoanData = (from l in bibliotecaDbContext.Loans
                                 from u in bibliotecaDbContext.Users
                                 where l.ID_user == u.Id
                                 select l).ToList();

            model.getBookData = (from b in bibliotecaDbContext.Books
                                 from u in bibliotecaDbContext.Users
                                 from l in bibliotecaDbContext.Loans
                                 where l.ID_Book == b.Id_book && l.ID_user == u.Id
                                 select b).ToList();
            return View(model);
        }
    }
}