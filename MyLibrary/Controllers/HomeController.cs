using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyLibrary.Models;
using MyLibrary.Repositories;
using MyLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyLibrary.Models.Exceptions;

namespace MyLibrary.Controllers
{
    [Route("[controller]/")]
    public class HomeController : Controller
    {
        User user;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("~/")]
        [Route("/Home")]
        [Route("~/Home/Index")]
        public IActionResult Index(User user)
        {
            // login/register form
            return View();
        }

        [HttpPost]
        [Route("login")]
        //[AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(string email, string password)
        {
            try
            {
                if (email == null || password == null) throw new AuthorizationException();

                user = UserRepository.Get(email, password);

                if (user == null) throw new AuthorizationException();


                var token = TokenService.CreateToken(user);
                user.Password = "";
                //return new
                //{
                //    user = user,
                //    token = token
                //};
                return RedirectToAction("Overview");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Route("Overview")]
        //[Authorize(Roles = "Administrator, Client")]
        public IActionResult Overview()
        {
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
