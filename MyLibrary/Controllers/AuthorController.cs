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
    //[Authorize(Roles = "Administrator, Client")]
    public class AuthorController : Controller
    {
        AuthorService authorService;


        [HttpGet]
        [Route("/Author")]
        [Route("~/Author/Index")]
        public IActionResult Index()
        {
            authorService = new AuthorService();
            List<Author> authors = authorService.GetList();

            return View(authors);
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult Index(string keyword)
        {
            authorService = new AuthorService();
            List<Author> authors = authorService.GetList();


            authors = authors.FindAll(x => x.FirstName == keyword || (DateTime.Now.Year - x.BirthDate.Year).ToString() == keyword);
            authors = SearchWithRegex(keyword, authors);

            return View(authors);
        }

        [HttpGet]
        [Route("Details")]
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
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Author author)
        {
            authorService = new AuthorService();
            try
            {
                if (!ModelState.IsValid) throw new ObjectCreationException();
                if (string.IsNullOrEmpty(author.FirstName) || string.IsNullOrEmpty(author.LastName)) throw new ObjectCreationException();
                authorService.Create(author);

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
        [Route("Edit")]
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
        [Route("Delete")]
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
        [Route("DeleteObject")]
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

        #region Helper methods
        private List<Author> SearchWithRegex(string keyword, List<Author> authors)
        {
            List<Author> temp = new List<Author>();
            Regex rgx = new Regex(keyword);
            authors.ForEach(x =>
            {
                if (rgx.IsMatch(x.FirstName + " " + x.LastName)) temp.Add(x);
            });

            return temp;
        }
        #endregion
    }
}
