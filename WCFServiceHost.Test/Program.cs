using System;
using System.Collections.Generic;
using System.Linq;
using WCFServiceHost.Models;

namespace WCFServiceHost.Test
{
    internal class Program
    {
        static void Main(string[] args) {
            using (var client = new ServiceClient.ServiceClient()) {
                Cliente clienteComId1 = client.ObterClientePorId(1);

                if (clienteComId1 != null) {
                    Console.WriteLine($"Dados do Cliente com ID 1:");
                    ExibirDetalhesCliente(clienteComId1);
                }
                else {
                    Console.WriteLine("Cliente com ID 1 não encontrado.");
                }

                List<Cliente> todosClientes = client.ObterClientes().ToList();

                Console.WriteLine($"\nTodos os Clientes:");
                foreach (var cliente in todosClientes) {
                    ExibirDetalhesCliente(cliente);
                }
            }
        }

        static void ExibirDetalhesCliente(Cliente cliente) {
            Console.WriteLine($"ID: {cliente.ClienteId}, Nome: {cliente.Nome}, CPF: {cliente.CPF}");
        }
    }
}
