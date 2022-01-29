using System.Collections.Generic;
using VettaProject.Api.Models;

namespace VettaProject.Api.Services.Interfaces
{
    public interface IClientService
    {
        void Save(Client clientRequest);

        void Edit(Client request);

        Client GetByCPF(string cpf);

        IEnumerable<Client> GetAll();

        void Delete(string cpf);
    }
}