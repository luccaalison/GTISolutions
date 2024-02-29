using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IClienteService
    {
        Cliente GetById(int id);
        IEnumerable<Cliente> GetAll();
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
    }
}
