using BibliotecaProject.Database;
using BibliotecaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaProject.Controllers
{
    public class LibrarianController : Controller
    {
       
        public readonly BibliotecaDbContext bibliotecaDbContext;

        public LibrarianController(BibliotecaDbContext bibliotecaDbContext)
        {

            this.bibliotecaDbContext = bibliotecaDbContext;

        }

        public IActionResult Purchase()
        {
            return View();
        }
        public IActionResult ListOfBooks()
        {

            var query = from b in bibliotecaDbContext.Books
                        select b;


            return View(query);

        }
        public IActionResult AddBooks()
        {
            return View();
        }
        public IActionResult DeleteBooks(Guid id)
        {

            var query = (from b in bibliotecaDbContext.Books
                         where b.Id_book == id
                         select b).FirstOrDefault();

            bibliotecaDbContext.Books.Remove(query);

            bibliotecaDbContext.SaveChanges();

            return Redirect("https://localhost:7190/Librarian/ListOfBooks");

        }
        public IActionResult HomeLibrarian()
        {
            return View();

        }

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
        public IActionResult AddUser()
        {

            return View();

        }


             [HttpPost]
              public IActionResult AddUser(string Name, string Surname, string ResidentialAddress, string FiscalCode, string Email, string PhoneNumber, string Type, string Emissary, DateTime ExpirationDate, string Password, int Age)
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

                  identityCard.ID_user = user.Id;

                  bibliotecaDbContext.SaveChanges();

                  return Redirect("https://localhost:7190/Dashboard");



      }
    }
}