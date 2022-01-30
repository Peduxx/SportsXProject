using System.Collections.Generic;
using Api.Controllers.DTOs.Request;
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
        public ActionResult Create([FromBody] NewClientRequest clientRequest)
        {
            //Mapeamento da entidade recebida na requisição para a entidade a ser enviada para a camada de service.
            Client client = _mapper.Map(clientRequest);

            //Chamada da camada de service.
            _clientService.Save(client);

            //Retorno de sucesso caso a requisição consiga salvar o registro enviado para o banco de dados.
            return StatusCode(201, "Cliente cadastrado com sucesso!");
        }

        //Endpoint responsável por criar um novo registro de cliente no banco de dados.
        [HttpPut]
        [Route("[action]")]
        public ActionResult Edit([FromQuery] string cpf, [FromBody] EditClientRequest clientRequest)
        {
            //Mapeia a entidade recebida para uma entidade de cliente.
            Client client = _mapper.Map(clientRequest);

            //Chamada da camada de service.
            _clientService.Edit(cpf, client);

            //Retorno de sucesso caso a requisição consiga salvar o registro atualizado.
            return StatusCode(200, "Cliente editado com sucesso! Novos dados foram salvos.");
        }

        //Endpoint responsável por buscar todos os registros de clientes existentes no banco de dados.
        [HttpGet]
        public ActionResult GetAllClients()
        {
            //Chamada da camada de service.
            IEnumerable<Client> clients = _clientService.GetAll();

            //Retorna sucesso e os clientes cadastrados no banco de dados.
            return StatusCode(200, clients);
        }

        //Endpoint responsável por deletar um registro de cliente no banco de dados.
        [HttpDelete]
        [Route("[action]")]
        public ActionResult Delete([FromQuery] string cpf)
        {
            //Chamada da camada de service.
            _clientService.Delete(cpf);

            //Retorno de sucesso caso a requisição consiga salvar o registro atualizado.
            return StatusCode(200, "O cliente foi deletado.");
        }
    }
}