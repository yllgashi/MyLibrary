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

        public IActionResult Index()
        {
            clientAccess = new ClientAccess();
            List<Client> clients = clientAccess.GetList();

            return View(clients);
        }

        public IActionResult Get(int id)
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
    }
}
