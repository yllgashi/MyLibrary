using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.DataService;
using MyLibrary.Models;
using MyLibrary.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
    [Route("[controller]/")]
    //[Authorize(Roles = "Administrator")]
    public class BookRentController : Controller
    {
        BookRentService bookRentService;

        [HttpGet]
        [HttpGet]
        [Route("/BookRent")]
        [Route("~/BookRent/Index")]
        public IActionResult Index()
        {
            bookRentService = new BookRentService();
            List<BookRent> bookRents = bookRentService.GetList();

            return View(bookRents);
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult Index(string keyword)
        {
            bookRentService = new BookRentService();
            List<BookRent> bookRents = bookRentService.GetList();
            bookRents = SearchWithRegex(keyword, bookRents);

            return View(bookRents);
        }

        [HttpGet]
        [Route("Details")]
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
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(BookRent bookRent)
        {
            bookRentService = new BookRentService();
            try
            {
                if (!ModelState.IsValid) throw new ObjectCreationException();
                bookRentService.Create(bookRent);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Route("Edit")]
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
        [Route("Edit")]
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
        [Route("Delete")]
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
        [Route("DeleteObject")]
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

        #region Helper methods
        private List<BookRent> SearchWithRegex(string searching, List<BookRent> bookRents)
        {
            List<BookRent> temp = new List<BookRent>();
            Regex rgx = new Regex(searching);
            bookRents.ForEach(x =>
            {
                if (rgx.IsMatch(x.Book.Title)) temp.Add(x);
            });

            return temp;
        }
        #endregion
    }
}
