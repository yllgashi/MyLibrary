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
    public class BookController : Controller
    {
        BookService bookService;

        [HttpGet]
        [Route("/Book")]
        [Route("~/Book/Index")]
        public IActionResult Index()
        {
            bookService = new BookService();
            List<Book> books = bookService.GetList();

            return View(books);
        }

        [Authorize(Roles = "Administrator, Client")]
        [HttpGet("~/book/get-books")]
        public List<Book> GetAuthors()
        {
            bookService = new BookService();
            List<Book> books = bookService.GetList();

            return books;
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult Index(string keyword)
        {
            bookService = new BookService();
            List<Book> books = bookService.GetList();
            books = SearchWithRegex(keyword, books);

            return View(books);
        }

        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int id)
        {
            bookService = new BookService();
            try
            {
                Book book = bookService.Get(id);

                return View(book);
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
        public IActionResult Create(Book book)
        {
            bookService = new BookService();
            try
            {
                if (!ModelState.IsValid) throw new ObjectCreationException();
                if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Summary) || string.IsNullOrEmpty(book.ISBN)) throw new ObjectCreationException();
                bookService.Create(book);

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
            bookService = new BookService();
            try
            {
                if (id == 0) throw new Exception();
                Book book = bookService.Get(id);
                return View(book);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Book book)
        {
            bookService = new BookService();
            try
            {
                bookService.Update(book.BookId, book);
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
            bookService = new BookService();
            try
            {
                if (id == 0) throw new Exception();
                Book book = bookService.Get(id);
                return View(book);
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
            bookService = new BookService();
            try
            {
                bookService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        #region Helper methods
        private List<Book> SearchWithRegex(string keyword, List<Book> books)
        {
            List<Book> temp = new List<Book>();
            Regex rgx = new Regex(keyword);
            books.ForEach(x =>
            {
                if (rgx.IsMatch(x.Title)) temp.Add(x);
            });

            return temp;
        }
        #endregion
    }
}
