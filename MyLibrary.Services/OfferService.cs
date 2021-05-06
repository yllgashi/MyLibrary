using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.DataService
{
    public class OfferService
    {
        OfferServiceAccess offerServiceAccess;

        public OfferService()
        {
            offerServiceAccess = new OfferServiceAccess();
        }

        public List<Offer> GetAll()
        {
            return offerServiceAccess.GetAll();
        }

        public Offer Get(string id)
        {
            return offerServiceAccess.Get(id);
        }

        public bool Create(Offer offerService)
        {
            return offerServiceAccess.Create(offerService);
        }

        public bool Update(string id, Offer offerService)
        {
            return offerServiceAccess.Update(id, offerService);
        }

        public bool Delete(string id)
        {
            return offerServiceAccess.Delete(id);
        }
    }
}
