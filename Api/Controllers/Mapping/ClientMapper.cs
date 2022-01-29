using System.Threading.Tasks;
using Api.Controllers.DTOs.Request;
using VettaProject.Api.Controllers.DTOs.Request;
using VettaProject.Api.Models;

namespace Api.Controllers.Mapping
{
    //Classe responsável por mapear os atributos recebidos na requisição para o objeto que será salvo no banco de dados.
    public class ClientMapper
    {
        public Client Map(NewClientRequest clientRequest)
        {
            return new Client()
            {
                Name = clientRequest.Name,
                SocialReason = clientRequest.SocialReason,
                CPF = clientRequest.CPF,
                CNPJ = clientRequest.CNPJ,
                Email = clientRequest.Email,
                CEP = clientRequest.CEP,
                PhoneNumber = clientRequest.PhoneNumber,
                Classification = clientRequest.Classification
            };
        }

        public Client Map(EditClientRequest clientRequest)
        {
            return new Client()
            {
                Name = clientRequest.Name,
                SocialReason = clientRequest.SocialReason,
                CPF = clientRequest.CPF,
                CNPJ = clientRequest.CNPJ,
                Email = clientRequest.Email,
                CEP = clientRequest.CEP,
                PhoneNumber = clientRequest.PhoneNumber,
                Classification = clientRequest.Classification
            };
        }
    }
}