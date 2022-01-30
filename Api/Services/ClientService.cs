using System;
using System.Collections.Generic;
using Api.Repositories.Interfaces;
using Api.Services.Validator;
using VettaProject.Api.Models;
using VettaProject.Api.Services.Interfaces;

namespace Api.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ClientValidator _validator;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _validator = new ClientValidator();
        }

        public void Save(Client clientRequest)
        {
            try
            {
                Client clientCheck = _clientRepository.GetByCPF(clientRequest.CPF);

                if (clientCheck != null)
                    throw new Exception("Esse CPF já está cadastrado no sistema.");

                _validator.Validate(clientRequest);

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
            catch (Exception)
            {
                throw;
            }
        }

        public void Edit(string cpf, Client clientRequest)
        {
            try
            {
                Client clientCheck = _clientRepository.GetByCPF(cpf);

                if (clientCheck == null)
                    throw new Exception("Cliente não cadastrado no sistema.");

                _validator.Validate(clientRequest);

                clientCheck.Name = clientRequest.Name;
                clientCheck.SocialReason = clientRequest.SocialReason;
                clientCheck.Email = clientRequest.Email;
                clientCheck.CEP = clientRequest.CEP;
                clientCheck.Classification = clientRequest.Classification;

                clientCheck.UpdatedDate = DateTime.Now;

                _clientRepository.Edit(clientCheck);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Client> GetAll()
        {
            try
            {
                List<Client> clients = _clientRepository.GetAll();

                return clients;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(string cpf)
        {
            try
            {
                Client client = _clientRepository.GetByCPF(cpf);

                if (client == null)
                    throw new Exception("Cliente não cadastrado no sistema.");

                _clientRepository.Delete(client);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}