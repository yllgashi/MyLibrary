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

        [HttpGet]
        public IActionResult Index()
        {
            bookRentService = new BookRentService();
            List<BookRent> bookRents = bookRentService.GetList();

            return View(bookRents);
        }

        [HttpPost]
        public IActionResult Index(int searching)
        {
            bookRentService = new BookRentService();
            List<BookRent> bookRents = bookRentService.GetList();
            bookRents = bookRents.FindAll(x => x.BookRentId == searching);

            return View(bookRents);
        }

        [HttpGet]
        public IActionResult Details(int id)
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookRent bookRent)
        {
            bookRentService = new BookRentService();
            try
            {
                bookRentService.Create(bookRent);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            bookRentService = new BookRentService();
            try
            {
                if (id == 0) throw new Exception();
                BookRent bookRent = bookRentService.Get(id);
                return View(bookRent);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit(BookRent bookRent)
        {
            bookRentService = new BookRentService();
            try
            {
                bookRentService.Update(bookRent.BookRentId, bookRent);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            bookRentService = new BookRentService();
            try
            {
                if (id == 0) throw new Exception();
                BookRent bookRent = bookRentService.Get(id);
                return View(bookRent);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult DeleteObject(int id)
        {
            bookRentService = new BookRentService();
            try
            {
                bookRentService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
