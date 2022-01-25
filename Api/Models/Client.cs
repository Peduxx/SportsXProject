using VettaProject.Api.Models.Base;
using System;
using VettaProject.Api.Models.Enum;
using System.Collections.Generic;
using Api.Models;
using System.ComponentModel.DataAnnotations;

namespace VettaProject.Api.Models
{
    //Entidade de cliente.
    public class Client : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string SocialReason { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }

        [Required]
        public string Email { get; set; }

        public string CEP { get; set; }

        public IEnumerable<PhoneNumber> PhoneNumber { get; set; }

        [Required]
        public Classification Classification { get; set; }

        public static Client Create(string name, string socialReason, string cnpj, string cpf, string email, string cep, IEnumerable<PhoneNumber> phoneNumber, Classification classification)
        {
            return new()
            {
                Name = name,
                SocialReason = socialReason,
                CPF = cpf,
                CNPJ = cnpj,
                Email = email,
                CEP = cep,
                PhoneNumber = phoneNumber,
                Classification = classification,
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
        }

    }
}