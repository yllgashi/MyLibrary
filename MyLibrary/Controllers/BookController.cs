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
    [Authorize(Roles = "Administrator, Client")]
    public class BookController : Controller
    {
        BookService bookService;

        [HttpGet]
        public IActionResult Index()
        {
            bookService = new BookService();
            List<Book> books = bookService.GetList();

            return View(books);
        }

        [HttpPost]
        public IActionResult Index(string keyword)
        {
            bookService = new BookService();
            List<Book> books = bookService.GetList();
            books = SearchWithRegex(keyword, books);

            return View(books);
        }

        [HttpGet]
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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
