using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.DAL;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class EnderecoClienteRepository : IEnderecoClienteRepository
    {
        private readonly MyDbContext _context;

        public EnderecoClienteRepository(MyDbContext context) {
            _context = context;
        }

        public EnderecoCliente GetById(int id) {
            return _context.EnderecosClientes.Find(id);
        }

        public IEnumerable<EnderecoCliente> GetAll() {
            return _context.EnderecosClientes.ToList();
        }

        public void Add(EnderecoCliente enderecoCliente) {
            _context.EnderecosClientes.Add(enderecoCliente);
            _context.SaveChanges();
        }

        public void Update(EnderecoCliente enderecoCliente) {
            _context.Entry(enderecoCliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id) {
            var enderecoCliente = _context.EnderecosClientes.Find(id);
            if (enderecoCliente != null) {
                _context.EnderecosClientes.Remove(enderecoCliente);
                _context.SaveChanges();
            }
        }
    }

}