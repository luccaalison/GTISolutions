using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly Interfaces.IClienteService _clienteService;

        public ClienteController(Interfaces.IClienteService clienteService) {
            _clienteService = clienteService;
        }

        public IHttpActionResult Get() {
            var clientes = _clienteService.GetAll();
            return Ok(clientes);
        }

        public IHttpActionResult Get(int id) {
            var cliente = _clienteService.GetById(id);
            if (cliente == null) {
                return NotFound();
            }
            return Ok(cliente);
        }

        public IHttpActionResult Post([FromBody] Cliente cliente) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _clienteService.Add(cliente);
            return CreatedAtRoute("DefaultApi", new { id = cliente.ClienteId }, cliente);
        }

        public IHttpActionResult Put(int id, [FromBody] Cliente cliente) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != cliente.ClienteId) {
                return BadRequest();
            }

            _clienteService.Update(cliente);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id) {
            var clienteExistente = _clienteService.GetById(id);
            if (clienteExistente == null) {
                return NotFound();
            }

            _clienteService.Delete(id);
            return Ok();
        }
    }
}