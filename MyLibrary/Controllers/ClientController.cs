﻿using Microsoft.AspNetCore.Mvc;
using MyLibrary.DataService;
using MyLibrary.Models;
using MyLibrary.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
    public class ClientController : Controller
    {
        ClientService clientService;

        [HttpGet]
        public IActionResult Index()
        {
            clientService = new ClientService();
            List<Client> clients = clientService.GetList();

            return View(clients);
        }

        [HttpPost]
        public IActionResult Index(string keyword)
        {
            clientService = new ClientService();
            List<Client> clients = clientService.GetList();
            clients = clients.FindAll(x => x.FirstName + x.LastName == keyword);

            return View(clients);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            clientService = new ClientService();
            try
            {
                Client client = clientService.Get(id);

                return View(client);
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
        public IActionResult Create(Client client)
        {
            clientService = new ClientService();
            try
            {
                if (!ModelState.IsValid) throw new ObjectCreationException();
                if (string.IsNullOrEmpty(client.FirstName) || string.IsNullOrEmpty(client.LastName)) throw new ObjectCreationException();
                clientService.Create(client);

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
            clientService = new ClientService();
            try
            {
                if (id == 0) throw new Exception();
                Client client = clientService.Get(id);
                return View(client);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit(Client client)
        {
            clientService = new ClientService();
            try
            {
                clientService.Update(client.ClientId, client);
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
            clientService = new ClientService();
            try
            {
                if (id == 0) throw new Exception();
                Client client = clientService.Get(id);
                return View(client);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult DeleteObject(int id)
        {
            clientService = new ClientService();
            try
            {
                clientService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
