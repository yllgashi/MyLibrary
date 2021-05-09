using Microsoft.AspNetCore.Mvc;
using MyLibrary.Access;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
    public class ClientController : Controller
    {
        ClientAccess clientAccess;

        [HttpGet]
        public IActionResult Index()
        {
            clientAccess = new ClientAccess();
            List<Client> clients = clientAccess.GetList();

            return View(clients);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            clientAccess = new ClientAccess();
            try
            {
                Client client = clientAccess.Get(id);

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
            clientAccess = new ClientAccess();
            try
            {
                clientAccess.Create(client);

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
            clientAccess = new ClientAccess();
            try
            {
                if (id == 0) throw new Exception();
                Client client = clientAccess.Get(id);
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
            clientAccess = new ClientAccess();
            try
            {
                clientAccess.Update(client.ClientId, client);
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
            clientAccess = new ClientAccess();
            try
            {
                if (id == 0) throw new Exception();
                Client client = clientAccess.Get(id);
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
            clientAccess = new ClientAccess();
            try
            {
                clientAccess.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
