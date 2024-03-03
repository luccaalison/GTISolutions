using System;
using System.Collections.Generic;
using System.Linq;
using WebForm.WCFService;

namespace WebForms
{
    public class ClientePresenter
    {
        private readonly ServiceImplementation _servicoWCF;

        public ClientePresenter()
        {
            _servicoWCF = new ServiceImplementation();
        }

        public List<Cliente> ObterClientes()
        {
            return _servicoWCF.ObterClientes().ToList();
        }

        public Cliente ObterClientePorCPF(string cpf)
        {
            return _servicoWCF.BuscarClientePorCPF(cpf);
        }

        public void AdicionarCliente(Cliente cliente)
        {
            _servicoWCF.AdicionarCliente(cliente);
        }

        public void EditarCliente(int clienteId,  Cliente clienteAtualizado)
        {
            _servicoWCF.EditarCliente(clienteId, false, clienteAtualizado);
        }

        public void ExcluirCliente(int clienteId)
        {
            _servicoWCF.ExcluirCliente(clienteId, false);
        }
    }
}
