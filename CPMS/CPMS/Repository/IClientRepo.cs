using CPMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Repository
{
    public interface IClientRepo
    {

        Task<Client> getClientById(int id);
        Task<List<Client>> getAllClients(string sortBy, string orderBy, string searchByName);
        Task<bool> AddClient(Client client);
        Task<bool> UpdateClient(int id, Client client);
        Task<Client> DeleteClient(int id);
        Task<Client> SignIn(string email, string password);
 
    }
}
