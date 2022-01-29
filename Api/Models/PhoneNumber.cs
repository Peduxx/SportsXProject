using System;
using VettaProject.Api.Models.Base;

namespace Api.Models
{
    //Entidade de telefone.
    public class PhoneNumber : BaseEntity
    {
        public int ClientId { get; set; }

        public string Number { get; set; }

        public static PhoneNumber Create(string number)
        {
            return new()
            {
                Number = number,
            };
        }
    }
}