using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjDotnetMongo.Models;
using ProjDotnetMongo.Services;

namespace ProjDotnetMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> Get() =>
            _clienteService.Get();

        
        [HttpGet("{id:length(24)}", Name = "GetCliente")]
        public ActionResult<Cliente> Get(string id)
        {
            var cliente = _clienteService.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public ActionResult<Cliente> Create(Cliente cliente)
        {
            _clienteService.Create(cliente);

            return CreatedAtRoute("GetCliente", new { id = cliente.Id.ToString() }, cliente);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Cliente clienteIn)
        {
            var cliente = _clienteService.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteService.Update(id, clienteIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var cliente = _clienteService.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clienteService.Remove(cliente.Id);

            return NoContent();
        }
    }
}