using System.Collections.Generic;
using Api.Models;
using VettaProject.Api.Models.Enum;

namespace Api.Controllers.DTOs.Request
{
    public class EditClientRequest
    {
        public string Name { get; set; }

        public string SocialReason { get; set; }

        public string Email { get; set; }

        public string CEP { get; set; }

        public Classification Classification { get; set; }
    }
}