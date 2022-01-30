using System.Collections.Generic;
using VettaProject.Api.Models;

namespace VettaProject.Api.Services.Interfaces
{
    public interface IClientService
    {
        void Save(Client clientRequest);

        void Edit(string cpf, Client request);

        List<Client> GetAll();

        void Delete(string cpf);
    }
}