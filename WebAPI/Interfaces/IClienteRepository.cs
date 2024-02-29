using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DAL;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IClienteRepository
    {
        Cliente GetById(int id);
        IEnumerable<Cliente> GetAll();
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
    }

   
}
