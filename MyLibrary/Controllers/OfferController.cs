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
    public class OfferController : Controller
    {
        OfferService offerService;

        [HttpGet]
        public IActionResult Index()
        {
            offerService = new OfferService();
            List<Offer> offers = offerService.GetList();

            return View(offers);
        }

        [HttpPost]
        public IActionResult Index(string keyword)
        {
            offerService = new OfferService();
            List<Offer> offers = offerService.GetList();
            offers = offers.FindAll(x => x.Description == keyword);

            return View(offers);
        }

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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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
    }
}
