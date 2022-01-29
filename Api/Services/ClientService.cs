using System;
using System.Collections.Generic;
using Api.Repositories.Interfaces;
using VettaProject.Api.Models;
using VettaProject.Api.Services.Interfaces;

namespace Api.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void Save(Client clientRequest)
        {
            if (Convert.ToBoolean(_clientRepository.GetByCPF(clientRequest.CPF)))
                throw new Exception("Cliente já cadastrado no sistema.");

            Client client = Client.Create(
                                         clientRequest.Name,
                                         clientRequest.SocialReason,
                                         clientRequest.CNPJ,
                                         clientRequest.CPF,
                                         clientRequest.Email,
                                         clientRequest.CEP,
                                         clientRequest.PhoneNumber,
                                         clientRequest.Classification
                                        );

            _clientRepository.Save(client);
        }

        public void Edit(Client clientRequest)
        {
            Client clientCheck = _clientRepository.GetByCPF(clientRequest.CPF);

            if (clientCheck == null)
                throw new Exception("Cliente não cadastrado no sistema.");

            clientCheck.Name = clientRequest.Name;
            clientCheck.SocialReason = clientRequest.SocialReason;
            clientCheck.CPF = clientRequest.CPF;
            clientCheck.CNPJ = clientRequest.CNPJ;
            clientCheck.Email = clientRequest.Email;
            clientCheck.CEP = clientRequest.CEP;
            clientCheck.Classification = clientRequest.Classification;

            clientCheck.UpdatedDate = DateTime.Now;

            _clientRepository.Edit(clientCheck);
        }

        public Client GetByCPF(string cpf)
        {
            Client clientCheck = _clientRepository.GetByCPF(cpf);
            if (clientCheck == null)
                throw new Exception("Cliente não cadastrado no sistema.");

            Client client = _clientRepository.GetByCPF(cpf);

            return client;
        }

        public IEnumerable<Client> GetAll()
        {
            IEnumerable<Client> clients = _clientRepository.GetAll();

            return clients;
        }

        public void Delete(string cpf)
        {
            Client client = _clientRepository.GetByCPF(cpf);

            if (client == null)
                throw new Exception("Cliente não cadastrado no sistema.");

            _clientRepository.Delete(client);
        }
    }
}