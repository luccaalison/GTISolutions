using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EnderecoClienteController : ApiController
    {
        private readonly IEnderecoClienteService _enderecoClienteService;

        public EnderecoClienteController(IEnderecoClienteService enderecoClienteService) {
            _enderecoClienteService = enderecoClienteService;
        }

        public IHttpActionResult Get() {
            var enderecos = _enderecoClienteService.GetAll();
            return Ok(enderecos);
        }

        public IHttpActionResult Get(int id) {
            var endereco = _enderecoClienteService.GetById(id);
            if (endereco == null) {
                return NotFound();
            }
            return Ok(endereco);
        }

        public IHttpActionResult Post([FromBody] EnderecoCliente enderecoCliente) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _enderecoClienteService.Add(enderecoCliente);
            return CreatedAtRoute("DefaultApi", new { id = enderecoCliente.EnderecoClienteId }, enderecoCliente);
        }

        public IHttpActionResult Put(int id, [FromBody] EnderecoCliente enderecoCliente) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != enderecoCliente.EnderecoClienteId) {
                return BadRequest();
            }

            _enderecoClienteService.Update(enderecoCliente);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id) {
            var enderecoExistente = _enderecoClienteService.GetById(id);
            if (enderecoExistente == null) {
                return NotFound();
            }

            _enderecoClienteService.Delete(id);
            return Ok();
        }
    }
}