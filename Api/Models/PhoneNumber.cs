using System;
using VettaProject.Api.Models.Base;

namespace Api.Models
{
    //Entidade de telefone.
    public class PhoneNumber : BaseEntity
    {
        public int ClientId { get; set; }

        public string PostalCode { get; set; }

        public string DDD { get; set; }

        public string Number { get; set; }

        public static PhoneNumber Create(string postalCode, string ddd, string number)
        {
            return new()
            {
                PostalCode = postalCode,
                DDD = ddd,
                Number = number,
                CreationDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
        }
    }
}