using BibliotecaProject.Database;
using Microsoft.AspNetCore.Mvc;
using BibliotecaProject.Models;

namespace BibliotecaProject.Controllers
{

    public class UserController : Controller
    {
        public readonly BibliotecaDbContext bibliotecaDbContext;

        public UserController(BibliotecaDbContext bibliotecaDbContext)
        {

            this.bibliotecaDbContext = bibliotecaDbContext;

        }

        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult Contattaci()
        {
            return View();
        }
        public IActionResult HomeUser()
        {
            return View();

        }
        public IActionResult dashboardUser()
        {
            IndexModel model = new IndexModel();


            model.getLoanData = (from l in bibliotecaDbContext.Loan
                                 from u in bibliotecaDbContext.Users
                                 where l.ID_user == u.Id
                                 select l).ToList();

            model.getBookData = (from b in bibliotecaDbContext.Books
                                 from u in bibliotecaDbContext.Users
                                 from l in bibliotecaDbContext.Loan
                                 where l.ID_Book == b.Id_book && l.ID_user == u.Id
                                 select b).ToList();





            return View(model);

        }
    }
}
