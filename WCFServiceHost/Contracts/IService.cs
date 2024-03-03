using System.Collections.Generic;
using System.ServiceModel;
using WCFServiceHost.Models;

namespace WCFServiceHost.Contracts
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<Cliente> ObterClientes();

        [OperationContract]
        void AdicionarCliente(Cliente cliente);

        [OperationContract]
        void EditarCliente(int clienteId, Cliente clienteAtualizado);

        [OperationContract]
        void ExcluirCliente(int clienteId);

        [OperationContract]
        Cliente BuscarClientePorCPF(string cpf);
    }
}
