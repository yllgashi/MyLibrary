using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.DataService
{
    public class ClientOfferService
    {
        ClietOfferAccess clientOfferAccess;

        public ClientOfferService()
        {
            clientOfferAccess = new ClietOfferAccess();
        }

        public List<ClientOffer> GetAll()
        {
            return clientOfferAccess.GetAll();
        }

        public Book Get(string id)
        {
            return clientOfferAccess.Get(id);
        }

        public bool Create(ClientOffer clientOffer)
        {
            return clientOfferAccess.Create(clientOffer);
        }

        public bool Update(string id, ClientOffer clientOffer)
        {
            return clientOfferAccess.Update(id, clientOffer);
        }

        public bool Delete(string id)
        {
            return clientOfferAccess.Delete(id);
        }
    }
}
