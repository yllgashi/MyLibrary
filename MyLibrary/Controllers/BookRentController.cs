using Microsoft.AspNetCore.Mvc;
using MyLibrary.DataService;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
    public class BookRentController : Controller
    {
        BookRentService bookRentService;

        public IActionResult Index()
        {
            bookRentService = new BookRentService();
            List<BookRent> bookRents = bookRentService.GetList();

            return View(bookRents);
        }

        public IActionResult Get(int id)
        {
            bookRentService = new BookRentService();
            try
            {
                BookRent bookRent = bookRentService.Get(id);

                return View(bookRent);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
