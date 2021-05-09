using Microsoft.AspNetCore.Mvc;
using MyLibrary.Access;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
    public class CategoryController : Controller
    {
        CategoryAccess categoryAccess;

        [HttpGet]
        public IActionResult Index()
        {
            categoryAccess = new CategoryAccess();
            List<Category> categories = categoryAccess.GetList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            categoryAccess = new CategoryAccess();
            try
            {
                Category category = categoryAccess.Get(id);

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
            categoryAccess = new CategoryAccess();
            try
            {
                categoryAccess.Create(category);

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
            categoryAccess = new CategoryAccess();
            try
            {
                if (id == 0) throw new Exception();
                Category category = categoryAccess.Get(id);
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
            categoryAccess = new CategoryAccess();
            try
            {
                categoryAccess.Update(category.CategoryId, category);
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
            categoryAccess = new CategoryAccess();
            try
            {
                if (id == 0) throw new Exception();
                Category category = categoryAccess.Get(id);
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
            categoryAccess = new CategoryAccess();
            try
            {
                categoryAccess.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
