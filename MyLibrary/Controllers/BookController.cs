﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            bookService = new BookService();
            List<Book> books = bookService.GetList();

            return View(books);
        }

        public IActionResult Get(int id)
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
    }
}
