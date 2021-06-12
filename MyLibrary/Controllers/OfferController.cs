using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.DataService;
using MyLibrary.Models;
using MyLibrary.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyLibrary.Controllers
{
    //[Authorize(Roles = "Administrator, Client")]
    public class OfferController : Controller
    {
        OfferService offerService;

        [HttpGet]
        [Route("/Offer")]
        [Route("~/Offer/Index")]
        public IActionResult Index()
        {
            offerService = new OfferService();
            List<Offer> offers = offerService.GetList();

            return View(offers);
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult Index(string keyword)
        {
            offerService = new OfferService();
            List<Offer> offers = offerService.GetList();
            offers = SearchWithRegex(keyword, offers);

            return View(offers);
        }

        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int id)
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

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Offer offer)
        {
            offerService = new OfferService();
            try
            {
                if (!ModelState.IsValid) throw new ObjectCreationException();
                if (string.IsNullOrEmpty(offer.Description)) throw new ObjectCreationException();
                offerService.Create(offer);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            offerService = new OfferService();
            try
            {
                if (id == 0) throw new Exception();
                Offer offer = offerService.Get(id);
                return View(offer);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Offer offer)
        {
            offerService = new OfferService();
            try
            {
                offerService.Update(offer.OfferId, offer);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            offerService = new OfferService();
            try
            {
                if (id == 0) throw new Exception();
                Offer offer = offerService.Get(id);
                return View(offer);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [Route("DeleteObject")]
        public IActionResult DeleteObject(int id)
        {
            offerService = new OfferService();
            try
            {
                offerService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        #region Helper methods
        private List<Offer> SearchWithRegex(string keyword, List<Offer> books)
        {
            List<Offer> temp = new List<Offer>();
            Regex rgx = new Regex(keyword);
            books.ForEach(x =>
            {
                if (rgx.IsMatch(x.Description)) temp.Add(x);
            });

            return temp;
        }
        #endregion
    }
}
