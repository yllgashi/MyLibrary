using Microsoft.AspNetCore.Mvc;
using MyLibrary.DataService;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
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
            List<Book> book = bookService.GetList();
            book = book.FindAll(x => x.Title == keyword);

            return View(book);
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
    }
}
