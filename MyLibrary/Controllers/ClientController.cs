using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            string json = "asd";


            return View(json);
        }
    }
}
