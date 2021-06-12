using Microsoft.AspNetCore.Mvc;
using MyLibrary.DataService;
using MyLibrary.Models;
using MyLibrary.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MyLibrary.Controllers
{
    //[Authorize(Roles = "Administrator")]
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
            clients = SearchWithRegex(keyword, clients);

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
        #region Helper methods
        private List<Client> SearchWithRegex(string keyword, List<Client> clients)
        {
            List<Client> temp = new List<Client>();
            Regex rgx = new Regex(keyword);
            clients.ForEach(x =>
            {
                if (rgx.IsMatch(x.FirstName + "" + x.LastName)) temp.Add(x);
            });

            return temp;
        }
        #endregion

    }
}
