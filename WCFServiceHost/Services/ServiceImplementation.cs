using System.Collections.Generic;
using WCFServiceHost.Contracts;
using WCFServiceHost.Helpers;
using WCFServiceHost.Models;

namespace WCFServiceHost.Services
{
    public class ServiceImplementation : IService
    {
        public string GetData(int value) {
            return $"Você inseriu: {value}";
        }

        public List<Cliente> ObterClientes() {
            return HelperBancoDeDados.ObterClientes();
        }

        public void AdicionarCliente(Cliente cliente) {
            HelperBancoDeDados.AdicionarCliente(cliente);
        }

        public void EditarCliente(int clienteId, Cliente clienteAtualizado) {
            HelperBancoDeDados.EditarCliente(clienteId, clienteAtualizado);
        }

        public void ExcluirCliente(int clienteId) {
            HelperBancoDeDados.ExcluirCliente(clienteId);
        }

        public Cliente BuscarClientePorCPF(string cpf) {
            return HelperBancoDeDados.BuscarClientePorCPF(cpf);
        }
    }
}
