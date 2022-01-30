using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Api.Models;
using Newtonsoft.Json;
using VettaProject.Api.Models.Enum;

namespace VettaProject.Api.Controllers.DTOs.Request
{
    //Entidade responsável por mapear e validar os dados recebidos na requisição.
    public class NewClientRequest
    {
        public string Name { get; set; }

        public string SocialReason { get; set; }

        public string Email { get; set; }

        public IEnumerable<PhoneNumber> PhoneNumber { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }

        public string CEP { get; set; }

        public Classification Classification { get; set; }
    }
}