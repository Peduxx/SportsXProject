using System.Threading.Tasks;
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

        public async Task Save(Client clientRequest)
        {

            Client client = Client.Create(
                                         clientRequest.Name,
                                         clientRequest.SocialReason,
                                         clientRequest.CPF,
                                         clientRequest.CNPJ,
                                         clientRequest.Email,
                                         clientRequest.CEP,
                                         clientRequest.PhoneNumber,
                                         clientRequest.Classification
                                                );

            await _clientRepository.Save(client);
        }
    }
}