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

        public IActionResult Index()
        {
            categoryAccess = new CategoryAccess();
            List<Category> categories = categoryAccess.GetList();

            return View(categories);
        }

        public IActionResult Get(int id)
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
    }
}
