using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class EnderecoClienteService : IEnderecoClienteService
    {
        private readonly IEnderecoClienteRepository _enderecoClienteRepository;

        public EnderecoClienteService(IEnderecoClienteRepository enderecoClienteRepository) {
            _enderecoClienteRepository = enderecoClienteRepository;
        }

        public EnderecoCliente GetById(int id) {
            return _enderecoClienteRepository.GetById(id);
        }

        public IEnumerable<EnderecoCliente> GetAll() {
            return _enderecoClienteRepository.GetAll();
        }

        public void Add(EnderecoCliente enderecoCliente) {
            _enderecoClienteRepository.Add(enderecoCliente);
        }

        public void Update(EnderecoCliente enderecoCliente) {
            _enderecoClienteRepository.Update(enderecoCliente);
        }

        public void Delete(int id) {
            _enderecoClienteRepository.Delete(id);
        }
    }
}