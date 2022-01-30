using System;
using System.Text.RegularExpressions;
using VettaProject.Api.Models;

namespace Api.Services.Validator
{
    //Classe resposnável por validar os dados enviados nas requisições referentes ao contexto de Cliente.
    public class ClientValidator
    {
        Regex emailRegex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

        public void Validate(Client client)
        {
            if (String.IsNullOrEmpty(client.Name))
                throw new Exception("Nome é obrigatório.");

            if (client.Name.Length > 100)
                throw new Exception("O nome do cliente deve ter até 100 caracteres.");

            if (client.SocialReason.Length > 100)
                throw new Exception("Razão social deve ter até 100 caracteres.");

            if (String.IsNullOrEmpty(client.Email))
                throw new Exception("Email é obrigatório.");

            if (!emailRegex.IsMatch(client.Email))
                throw new Exception("Email inválido.");

            if (String.IsNullOrEmpty(client.CEP))
                throw new Exception("CEP é obrigatório.");

            if (String.IsNullOrEmpty(client.SocialReason))
                throw new Exception("Razão Social é obrigatório.");
        }
    }
}