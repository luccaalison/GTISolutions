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
    public class ClienteRepository : IClienteRepository
    {
        private readonly MyDbContext _context;

        public ClienteRepository(MyDbContext context) {
            _context = context;
        }

        public Cliente GetById(int id) {
            return _context.Clientes.Include(c => c.Endereco).SingleOrDefault(c => c.ClienteId == id);
        }

        public IEnumerable<Cliente> GetAll() {
            return _context.Clientes.Include(c => c.Endereco).ToList();
        }

        public void Add(Cliente cliente) {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Update(Cliente cliente) {
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id) {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null) {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }

}