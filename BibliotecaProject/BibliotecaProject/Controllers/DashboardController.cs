using BibliotecaProject.Database;
using BibliotecaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BibliotecaProject.Controllers
{
    public class DashboardController : Controller
    {
        
        public readonly BibliotecaDbContext bibliotecaDbContext;

        public DashboardController(BibliotecaDbContext bibliotecaDbContext)
        {

            this.bibliotecaDbContext = bibliotecaDbContext;

        }

        public IActionResult AddBooks()
        {
            return View();
        }

        public IActionResult AddAdmin()
        {
            return View();
        }

        public IActionResult AddLibrarian()
        {
            return View();
        }


        public IActionResult ListOfBooks()
        {

            var query = from b in bibliotecaDbContext.Books
                        select b;


            return View(query);

        }

     /* [HttpGet]
        public IActionResult ListOfBooks(string search, string typeOfBooks, string publishingHouse)
        {

            IEnumerable query = null;
            ViewBag.parameter = null;
            ViewBag.parameter1 = null;
            ViewBag.parameter2 = null;

            if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(typeOfBooks) && string.IsNullOrEmpty(publishingHouse))
            {
                
                query = from b in bibliotecaDbContext.Books
                        select b;

            }
            else if(string.IsNullOrEmpty(typeOfBooks) && string.IsNullOrEmpty(publishingHouse))
            {

                ViewBag.parameter = search;

                query = from b in bibliotecaDbContext.Books
                            where b.Title.Contains(search)
                            select b;

            }else if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(publishingHouse))
            {
                ViewBag.parameter1 = typeOfBooks;

                query =    from b in bibliotecaDbContext.Books
                            where b.TypeOfBooks == typeOfBooks
                            select b;

            }else if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(typeOfBooks))
            {
                ViewBag.parameter2 = publishingHouse;

                query = from b in bibliotecaDbContext.Books
                            where b.PublishingHouse == publishingHouse
                            select b;

            }else if (string.IsNullOrEmpty(search)){

                ViewBag.parameter1 = typeOfBooks;
                ViewBag.parameter2 = publishingHouse;

                query = from b in bibliotecaDbContext.Books
                            where b.PublishingHouse == publishingHouse && 
                            b.TypeOfBooks == typeOfBooks
                            select b; 
                
            }else if (string.IsNullOrEmpty(typeOfBooks)){

                ViewBag.parameter = search;
                ViewBag.parameter2 = publishingHouse;

                query = from b in bibliotecaDbContext.Books
                            where b.Title.Contains(search) && 
                            b.PublishingHouse == publishingHouse
                            select b;
            }else{

                ViewBag.parameter = search;
                ViewBag.parameter1 = typeOfBooks;

                query = from b in bibliotecaDbContext.Books
                            where b.Title.Contains(search) && 
                            b.PublishingHouse == publishingHouse
                            select b;
            }

            return View(query);

        } */


        [HttpPost]
        public IActionResult AddBooks(string title, string author, string publishingHouse, int numberOfCopy, string typeOfBooks, string description, string isbn)
        {

            var books = new Book()
            {
                Title = title,
                Author = author,
                PublishingHouse = publishingHouse,
                NumberOfCopy = numberOfCopy,
                TypeOfBooks = typeOfBooks,
                Description = description,
                ISBN = isbn
            };

            bibliotecaDbContext.Books.Add(books);

            bibliotecaDbContext.SaveChanges();

            return Redirect("ListOfBooks");

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


        [HttpGet]
        public IActionResult EditBooks(Guid id)
        {


            var query = from b in bibliotecaDbContext.Books
                        where b.Id_book == id
                        select b;

            return View(query);

        }

        [HttpPost]
        public IActionResult EditBooks(string Title, string Author, string PublishingHouse, int NumberOfCopy, string TypeOfBooks, string Description, string ISBN)
        {


            var query = from b in bibliotecaDbContext.Books
                        where b.Title == Title && b.Author == Author && b.ISBN == ISBN
                        select b;

            foreach (var item in query)
            {
                item.Title = Title;
                item.Author = Author;
                item.PublishingHouse = PublishingHouse;
                item.NumberOfCopy = NumberOfCopy;
                item.TypeOfBooks = TypeOfBooks;
                item.Description = Description;
                item.ISBN = ISBN;
            }


            bibliotecaDbContext.SaveChanges();

            return Redirect("https://localhost:7190/Dashboard/ListOfBooks");
        }

        public IActionResult DeleteBooks(Guid id)
        {

            var query = (from b in bibliotecaDbContext.Books
                         where b.Id_book == id
                         select b).FirstOrDefault();

            bibliotecaDbContext.Books.Remove(query);

            bibliotecaDbContext.SaveChanges();

            return Redirect("https://localhost:7190/Dashboard/ListOfBooks");

        }


        public IActionResult AddUser()
        {

            return View();

        }


        [HttpPost]
        public IActionResult AddUser(string Name,string Surname,string ResidentialAddress,string FiscalCode, string Email,string PhoneNumber,string Type,string Emissary,DateTime ExpirationDate,string Password,int Age)
        {

            var user = new User()
            {
                Name = Name,
                Surname = Surname,
                ResidentialAddress = ResidentialAddress,
                FiscalCode = FiscalCode,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Password = Password,
                Role = "User"

            };

            var identityCard = new IdentityCard()
            {

                Type = Type,
                Emissary = Emissary,
                ExpirationDate = ExpirationDate

            };


            bibliotecaDbContext.Users.Add(user);

            bibliotecaDbContext.SaveChanges();

            bibliotecaDbContext.IdentityCards.Add(identityCard);

            identityCard.Id_user = user.Id;

            bibliotecaDbContext.SaveChanges();

            return Redirect("https://localhost:7190/Dashboard");

        }

    }
}
