using MyLibrary.Access;
using MyLibrary.Models;
using MyLibrary.Models.Exceptions;
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
            return clientAccess.GetList();
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
            // validation
            List<Client> clients = clientAccess.GetList();
            int exists = clients.FindIndex(x => x.FirstName == client.FirstName && x.LastName == client.LastName && x.BirthDate == client.BirthDate);
            if (exists != -1) throw new ObjectCreationException();
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
