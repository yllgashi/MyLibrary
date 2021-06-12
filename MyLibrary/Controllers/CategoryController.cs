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
    public class CategoryController : Controller
    {
        CategoryService categoryService;

        [HttpGet]
        public IActionResult Index()
        {
            categoryService = new CategoryService();
            List<Category> categories = categoryService.GetList();

            return View(categories);
        }

        [HttpPost]
        public IActionResult Index(string keyword)
        {
            categoryService = new CategoryService();
            List<Category> categories = categoryService.GetList();
            categories = SearchWithRegex(keyword, categories);

            return View(categories);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            categoryService = new CategoryService();
            try
            {
                Category category = categoryService.Get(id);

                return View(category);
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
        public IActionResult Create(Category category)
        {
            categoryService = new CategoryService();
            try
            {
                if (!ModelState.IsValid) throw new ObjectCreationException();
                if (string.IsNullOrEmpty(category.Description)) throw new ObjectCreationException();
                categoryService.Create(category);

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
            categoryService = new CategoryService();
            try
            {
                if (id == 0) throw new Exception();
                Category category = categoryService.Get(id);
                return View(category);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            categoryService = new CategoryService();
            try
            {
                categoryService.Update(category.CategoryId, category);
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
            categoryService = new CategoryService();
            try
            {
                if (id == 0) throw new Exception();
                Category category = categoryService.Get(id);
                return View(category);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult DeleteObject(int id)
        {
            categoryService = new CategoryService();
            try
            {
                categoryService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        #region Helper methods
        private List<Category> SearchWithRegex(string keyword, List<Category> categories)
        {
            List<Category> temp = new List<Category>();
            Regex rgx = new Regex(keyword);
            categories.ForEach(x =>
            {
                if (rgx.IsMatch(x.Description)) temp.Add(x);
            });

            return temp;
        }
        #endregion
    }
}
