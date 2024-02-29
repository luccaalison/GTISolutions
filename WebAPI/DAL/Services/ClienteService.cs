using WebAPI.Interfaces;
using WebAPI.Models;
using System.Collections.Generic;

namespace WebAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository) {
            _clienteRepository = clienteRepository;
        }

        public Cliente GetById(int id) {
            return _clienteRepository.GetById(id);
        }

        public IEnumerable<Cliente> GetAll() {
            return _clienteRepository.GetAll();
        }

        public void Add(Cliente cliente) {
            _clienteRepository.Add(cliente);
        }

        public void Update(Cliente cliente) {
            _clienteRepository.Update(cliente);
        }

        public void Delete(int id) {
            _clienteRepository.Delete(id);
        }
    }
}
