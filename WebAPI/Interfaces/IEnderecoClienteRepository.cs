using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IEnderecoClienteRepository
    {
        EnderecoCliente GetById(int id);
        IEnumerable<EnderecoCliente> GetAll();
        void Add(EnderecoCliente enderecoCliente);
        void Update(EnderecoCliente enderecoCliente);
        void Delete(int id);
    }
}
