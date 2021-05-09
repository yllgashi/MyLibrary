using Microsoft.AspNetCore.Mvc;
using MyLibrary.DataService;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
    public class OfferController : Controller
    {
        OfferService offerService;

        public IActionResult Index()
        {
            offerService = new OfferService();
            List<Offer> offers = offerService.GetList();

            return View(offers);
        }

        public IActionResult Get(int id)
        {
            offerService = new OfferService();
            try
            {
                Offer offer = offerService.Get(id);

                return View(offer);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
