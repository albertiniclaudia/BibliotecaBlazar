using BibliotecaProject.Database;
using BibliotecaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System;
using System.Diagnostics;
using System.Text;

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
            IndexModel indexModel = new IndexModel();

            indexModel.getUserData = (from u in bibliotecaDbContext.Users
                                      from p in bibliotecaDbContext.PurchaseQueues
                                      where u.Id == p.ID_user
                                      select u).ToList();

            indexModel.getPurchaseQueueData = (from p in bibliotecaDbContext.PurchaseQueues
                                               select p).ToList();

            return View(indexModel);
        }
        public IActionResult ListOfBooks()
        {
            IndexModel indexModel = new IndexModel();

            indexModel.getBookData = from b in bibliotecaDbContext.Books
                                     orderby b.Id_book
                                     select b;

            indexModel.getPosition = from p in bibliotecaDbContext.PositionBooks
                                     orderby p.ID_book
                                     select p;

            return View(indexModel);

        }
        public IActionResult AddBooks()
        {
            return View();
        }

        public IActionResult ReturnBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ReturnBook(string Isbn)
        {
            var query = (from b in bibliotecaDbContext.Books
                         from l in bibliotecaDbContext.Loans
                         where b.ISBN == Isbn && b.Id_book == l.ID_Book
                         select l).FirstOrDefault();

            var query2 = (from l in bibliotecaDbContext.Loans
                          from lq in bibliotecaDbContext.LoanQueues
                          from b in bibliotecaDbContext.Books
                          where l.ID_Book == lq.ID_book && b.ISBN == Isbn
                          orderby lq.Date
                          select lq).FirstOrDefault();

            bibliotecaDbContext.Loans.Remove(query);
            bibliotecaDbContext.LoanQueues.Remove(query2);
            bibliotecaDbContext.SaveChanges();

            return Redirect("https://localhost:7190/Librarian/ListOfBooks");
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
        public IActionResult AddBooks(string title, string author, string publishingHouse,int numberOfCopy ,string typeOfBooks, string description, string isbn,string imageUrl)
        {

            var room = new List<string>();

            var rack = new List<string>();

            var shelf = new List<string>();

            var place = new List<string>();

            var query2 = (from p in bibliotecaDbContext.PositionBooks
                          select p);

            foreach (var item in query2)
            {

                room.Add(item.Room);

                rack.Add(item.Rack);

                shelf.Add(item.Shelf);

                place.Add(item.Place);


            }

                // creating a StringBuilder object()

                Riprova:

                StringBuilder str_build = new StringBuilder();

                StringBuilder str_build1 = new StringBuilder();

                StringBuilder str_build2 = new StringBuilder();

                StringBuilder str_build3 = new StringBuilder();

                Random random = new Random();

                Random random1 = new Random();

                Random random2 = new Random();

                Random random3 = new Random();

                char letter;

               
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);

                double flt1 = random.NextDouble();
                int shift1 = Convert.ToInt32(Math.Floor(25 * flt1));
                letter = Convert.ToChar(shift + 65);
                str_build1.Append(letter);

                double flt2 = random.NextDouble();
                int shift2 = Convert.ToInt32(Math.Floor(25 * flt2));
                letter = Convert.ToChar(shift + 65);
                str_build2.Append(letter);

                double flt3 = random.NextDouble();
                int shift3 = Convert.ToInt32(Math.Floor(25 * flt3));
                letter = Convert.ToChar(shift + 65);
                str_build3.Append(letter);
                bool valid = true;

                for (int space = 0; space < room.Count; space++)
                {
                    if (room[space] != str_build.ToString() || rack[space] != str_build1.ToString()
                        || shelf[space] != str_build2.ToString() || place[space] != str_build3.ToString())
                    {

                    }
                    else
                    {
                        valid = false;
                    }
                }
                if (valid)
                {

                    for (int i = 0; i < numberOfCopy; i++)
                    {
                            var books = new Book()
                            {
                                Id_book = Guid.NewGuid(),
                                Title = title,
                                Author = author,
                                ImageUrl = imageUrl,
                                PublishingHouse = publishingHouse,
                                TypeOfBooks = typeOfBooks,
                                Description = description,
                                ISBN = isbn
                            };

                            var position = new PositionBook()
                            {
                                ID_book = books.Id_book,
                                Room = str_build.ToString(),
                                Rack = str_build1.ToString(),
                                Shelf = str_build2.ToString(),
                                Place = str_build3.ToString()
                            };

                            bibliotecaDbContext.Books.Add(books);
                            bibliotecaDbContext.SaveChanges();

                            bibliotecaDbContext.PositionBooks.Add(position);
                            bibliotecaDbContext.SaveChanges();


                }

            }else { goto Riprova; }


            var query = (from p in bibliotecaDbContext.PurchaseQueues
                        where p.Title == title
                        select p).FirstOrDefault();

            if (query != null) {

                bibliotecaDbContext.PurchaseQueues.Remove(query);
            }

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
        public IActionResult EditBooks(string Title, string Author, string PublishingHouse, string TypeOfBooks, string Description, string ISBN)
        {

            int getTotalCount = (from b in bibliotecaDbContext.Books
                                 where b.Title == Title
                                 select b).Count();

            var query = from b in bibliotecaDbContext.Books
                        where b.Title == Title && b.Author == Author && b.ISBN == ISBN
                        select b;

            foreach (var item in query)
            {
                item.Title = Title;
                item.Author = Author;
                item.PublishingHouse = PublishingHouse;
                item.TypeOfBooks = TypeOfBooks;
                item.Description = Description;
                item.ISBN = ISBN;
            }


            bibliotecaDbContext.SaveChanges();

            return Redirect("https://localhost:7190/Librarian/ListOfBooks");

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

                  return Redirect("https://localhost:7190/Librarian/HomeLibrarian");



      }
    }
}