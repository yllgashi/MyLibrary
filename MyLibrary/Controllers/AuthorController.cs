﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult GetList()
        {
            authorService = new AuthorService();
            List<Author> authors = authorService.GetList();

            return View(authors);
        }

        public IActionResult Get()
        {
            authorService = new AuthorService();
            Author author = authorService.Get(1);
            
            return View(author);
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
