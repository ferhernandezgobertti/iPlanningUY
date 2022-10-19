using DataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClientDataAccess
    {
        public ClientDataAccess()
        {
        }

        public void SaveChanges()
        {
            using (Context context = new Context())
            {
                context.SaveChanges();
            }
        }

        public void AddClient(Client clientToBeAdded)
        {
            using (var context = new Context())
            {
                context.Clients.Add(clientToBeAdded);
                context.SaveChanges();
            }
        }

        public void RemoveClient(Client clientForRemoval)
        {
            using (Context context = new Context())
            {
               
                clientForRemoval = context.Clients.Find(clientForRemoval.Id);
                context.Entry(clientForRemoval).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void ModifyClient(Client client, Client clientWithNewData)
        {
            using (Context context = new Context())
            {
                context.Clients.Attach(client);
                client = context.Clients.Find(client.Id);
                client.Name = clientWithNewData.Name;
                client.Surname = clientWithNewData.Surname;
                client.UserName = clientWithNewData.UserName;
                client.Telephone = clientWithNewData.Telephone;
                client.NumberID = clientWithNewData.NumberID;
                client.Address = clientWithNewData.Address;
                context.Entry(client).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Client> GetClients()
        {
            List<Client> client = new List<Client>();
            using (Context context = new Context())
            {
                client = context.Clients.ToList();
            }
            return client;
        }

        public bool ClientExists(Client client)
        {
            bool exists = false;
            using (Context context = new Context())
            {
                client = context.Clients.Find(client.Id);
                exists = (client != null);
            }
            return exists;
        }

        public bool IdNumberExists(Client client)
        {
            bool exists = false;
            using (Context context = new Context())
            {
                client = context.Clients.Find(client.NumberID);
                exists = (client != null);
            }
            return exists;
        }

        public Client GetClient(Client client)
        {
            Client returnClient = null;
            using (Context context = new Context())
            {
                returnClient = context.Clients.First(a => a.Id == client.Id);
            }
            return returnClient;
        }
    }
}
