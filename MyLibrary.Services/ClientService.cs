using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.DataService
{
    public class ClientService
    {
        ClientAccess clientAccess;

        public ClientService()
        {
            clientAccess = new ClientAccess();
        }

        public List<Client> GetList()
        {
            return clientAccess.GetAll();
        }

        public Client Get(int id)
        {
            // usp_Client_Get_Offers
            // usp_BookRent_Get_By_Client
            // usp_Client_Get
            return clientAccess.Get(id);
        }

        public bool Create(Client client)
        {
            return clientAccess.Create(client);
        }

        public bool Update(int id, Client client)
        {
            return clientAccess.Update(id, client);
        }

        public bool Delete(int id)
        {
            return clientAccess.Delete(id);
        }

    }
}
