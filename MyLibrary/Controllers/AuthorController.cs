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
            authorService = new AuthorService();
            List<Author> authors = authorService.GetList();

            return View(authors);
        }

        public IActionResult Get(int id)
        {
            authorService = new AuthorService();
            try
            {
                Author author = authorService.Get(id);

                return View(author);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
