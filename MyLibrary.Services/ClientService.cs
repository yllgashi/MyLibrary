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

        public List<Client> GetAll()
        {
            return clientAccess.GetAll();
        }

        public Client Get(string id)
        {
            return clientAccess.Get(id);
        }

        public bool Create(Client client)
        {
            return clientAccess.Create(client);
        }

        public bool Update(string id, Client client)
        {
            return clientAccess.Update(id, client);
        }

        public bool Delete(string id)
        {
            return clientAccess.Delete(id);
        }

    }
}
