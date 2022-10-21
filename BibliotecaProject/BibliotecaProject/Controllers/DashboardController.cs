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

		public IActionResult HomeUser()
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

    }
}
