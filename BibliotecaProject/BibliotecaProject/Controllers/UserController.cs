using BibliotecaProject.Database;
using Microsoft.AspNetCore.Mvc;
using BibliotecaProject.Models;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http;

namespace BibliotecaProject.Controllers
{
    public class UserController : Controller
    {
       
		private readonly ILogger<UserController> _logger;
		public readonly BibliotecaDbContext bibliotecaDbContext;
		private readonly IHttpContextAccessor _http;
		public UserController(BibliotecaDbContext bibliotecaDbContext, IHttpContextAccessor httpContextAccessor)
		{
			this.bibliotecaDbContext = bibliotecaDbContext;
			_http = httpContextAccessor;
		}
		public IActionResult UserProfile()
        {
			string mail = _http.HttpContext.Session.GetString("email");
			Model2 model = new Model2();
			model.User = bibliotecaDbContext.Users.Where(u => u.Email == mail).FirstOrDefault();
			model.Loans = bibliotecaDbContext.Loans.Where(u => u.ID_user == model.User.Id && u.RentalEndData == null).ToList();
			model.EndedLoans = bibliotecaDbContext.Loans.Where(u => u.ID_user == model.User.Id && u.RentalEndData != null).ToList();
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
		public void RequestBook(string Title, string Author, string PublishingHouse, string ISBN)
		{
			string mail = _http.HttpContext.Session.GetString("email");
			var query = bibliotecaDbContext.Users.Where(u => u.Email == mail);
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
			_http.HttpContext.Response.Redirect("../User/HomeUser");
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