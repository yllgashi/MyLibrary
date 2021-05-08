using MyLibrary.Access;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.DataService
{
    public class OfferService
    {
        OfferAccess offerServiceAccess;

        public OfferService()
        {
            offerServiceAccess = new OfferAccess();
        }

        public List<Offer> GetList()
        {
            return offerServiceAccess.GetList();
        }

        public Offer Get(int id)
        {
            return offerServiceAccess.Get(id);
        }

        public bool Create(Offer offerService)
        {
            return offerServiceAccess.Create(offerService);
        }

        public bool Update(int id, Offer offerService)
        {
            return offerServiceAccess.Update(id, offerService);
        }

        public bool Delete(int id)
        {
            return offerServiceAccess.Delete(id);
        }
    }
}
