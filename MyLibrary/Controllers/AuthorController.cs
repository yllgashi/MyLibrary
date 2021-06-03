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

        [HttpGet]
        public IActionResult Index()
        {
            authorService = new AuthorService();
            List<Author> authors = authorService.GetList();

            return View(authors);
        }

        [HttpPost]
        public IActionResult Index(string keyword)
        {
            authorService = new AuthorService();
            List<Author> authors = authorService.GetList();
            authors = authors.FindAll(x => x.FirstName == keyword || (DateTime.Now.Year - x.BirthDate.Year).ToString() == keyword);

            return View(authors);
        }
        [HttpGet]
        public IActionResult Details(int id)
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            authorService = new AuthorService();
            try
            {
                authorService.Create(author);

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
            authorService = new AuthorService();
            try
            {
                if (id == 0) throw new Exception();
                Author author = authorService.Get(id);
                return View(author);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            authorService = new AuthorService();
            try
            {
                authorService.Update(author.AuthorId, author);
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
            authorService = new AuthorService();
            try
            {
                if (id == 0) throw new Exception();
                Author author = authorService.Get(id);
                return View(author);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult DeleteObject(int id)
        {
            authorService = new AuthorService();
            try
            {
                authorService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
