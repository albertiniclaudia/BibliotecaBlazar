using Microsoft.AspNetCore.Mvc;
using BibliotecaProject.Database;
using BibliotecaProject.Models;

namespace BibliotecaProject.Controllers
{
    public class AdminController : Controller
    {
         public readonly BibliotecaDbContext bibliotecaDbContext;

        public AdminController(BibliotecaDbContext bibliotecaDbContext)
        {
            
            this.bibliotecaDbContext = bibliotecaDbContext;

        }

        public IActionResult HomeAdmin()
        {
            return View();

        }

        public IActionResult OperatorsList()
        {

            var query = from u in bibliotecaDbContext.Parents
                        select u;
            return View(query);

        }

       [HttpGet]
        public IActionResult EditAdmin(Guid id)
        {


            var query = from u in bibliotecaDbContext.Users
                        where u.Id == id
                        select u;

            return View(query);

        }

        [HttpPost]
        public IActionResult EditAdmin(string Name, string Surname, string Email, string Role) {

            var query = from u in bibliotecaDbContext.Users
                        where u.Name == Name && u.Surname == Surname && u.Email == Email
                        select u;

            foreach (var item in query)
            {
                item.Name = Name;
                item.Surname = Surname;
                item.Email = Email;
                item.Role = Role;
            }


            bibliotecaDbContext.SaveChanges();

            return Redirect("https://localhost:7190/admin/OperatorsList");
        }
        public IActionResult DeleteAdmin(Guid id)
        {

            var query = (from u in bibliotecaDbContext.Parents
                         where u.Id == id
                         select u).FirstOrDefault();

            bibliotecaDbContext.Parents.Remove(query);

            bibliotecaDbContext.SaveChanges();

            return Redirect("https://localhost:7190/admin/OperatorsList");

        }
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(string Name, string Surname, string Email, string Password, string Role)
        {
            var user = new User()
            {
                Name = Name,
                Surname = Surname,
                Email = Email,
                Password = Password,
                Role = Role,
            };
            bibliotecaDbContext.Users.Add(user);

            bibliotecaDbContext.SaveChanges();

            return Redirect("https://localhost:7190/HomeAdmin");
        }

        public IActionResult AddLibrarian()
        {
            return View();
        }
    }
}