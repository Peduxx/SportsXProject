using System.Collections.Generic;
using VettaProject.Api.Models;

namespace Api.Repositories.Interfaces
{
    //Interface do repositório de cliente.
    public interface IClientRepository
    {
        void Save(Client clientPerson);

        void Edit(Client client);

        Client GetByCPF(string cpf);

        List<Client> GetAll();

        void Delete(Client client);
    }
}