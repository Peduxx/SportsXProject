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
        [Required]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Razão Social deve ter 100 caracteres.")]
        public string SocialReason { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public IEnumerable<PhoneNumber> PhoneNumber { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }

        public string CEP { get; set; }

        [Required]
        public Classification Classification { get; set; }
    }
}