using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Repositories.Interfaces;
using VettaProject.Api.Models;

namespace Api.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        //Salva um novo cliente no banco de dados.
        public void Save(Client client)
        {
            _context.Add(client);
            _context.SaveChanges();
        }

        //Altera os dados de um cliente no banco de dados.
        public void Edit(Client client)
        {
            _context.Update(client);
            _context.SaveChanges();
        }

        //Busca um usuário pelo CPF.
        public Client GetByCPF(string cpf)
        {
            Client client = _context.Clients.FirstOrDefault(c => c.CPF == cpf);

            if (client != null)
                client.PhoneNumber = _context.PhoneNumbers.ToList().Where(phoneNumber => phoneNumber.ClientId == client.Id);

            return client;
        }

        //Busca todos os clientes no banco de dados.
        public List<Client> GetAll()
        {
            List<Client> clients = _context.Clients.ToList();

            foreach (Client client in clients)
                client.PhoneNumber = _context.PhoneNumbers.ToList().Where(phoneNumber => phoneNumber.ClientId == client.Id);

            return clients;
        }

        //Deleta um cliente do banco de dados.
        public void Delete(Client client)
        {
            _context.Remove(client);
            _context.SaveChanges();
        }
    }
}