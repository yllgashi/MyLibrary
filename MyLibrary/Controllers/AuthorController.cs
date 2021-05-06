using Microsoft.AspNetCore.Mvc;
using MyLibrary.DataService;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
    public class AuthorController : Controller
    {
        AuthorService authorService;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            authorService = new AuthorService();
            List<Author> authors = authorService.GetAll();

            return View(authors);
        }

        //public IActionResult Create()
        //{
        //    Author author = new Author()
        //    {
        //        FirstName = "Filan",
        //        LastName = "Fisteku",
        //        BirthDate = DateTime.Now
        //    };

        //    authorService.Create(author);
        //}
    }
}
