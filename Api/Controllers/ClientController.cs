using System.Threading.Tasks;
using Api.Controllers.Mapping;
using Microsoft.AspNetCore.Mvc;
using VettaProject.Api.Controllers.DTOs.Request;
using VettaProject.Api.Models;
using VettaProject.Api.Services.Interfaces;

namespace VettaProject.Api.Controllers
{
    //Controller responsável por gerenciar os endpoints de pessoa física.

    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ClientMapper _mapper;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
            _mapper = new ClientMapper();
        }

        //Endpoint responsável por criar um novo registro de cliente no banco de dados.
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create([FromBody] NewClientRequest clientRequest)
        {
            Client client = _mapper.Map(clientRequest);

            await _clientService.Save(client);

            return StatusCode(200, "Cliente cadastrado com sucesso!");
        }
    }
}