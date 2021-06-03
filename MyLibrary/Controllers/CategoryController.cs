using Microsoft.AspNetCore.Mvc;
using MyLibrary.DataService;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
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
            categories = categories.FindAll(x => x.Description == keyword);

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
    }
}
