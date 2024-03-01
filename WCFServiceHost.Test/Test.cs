using System;
using System.Collections.Generic;
using WCFServiceHost.Models;
using WCFServiceHost.Test.ServiceClient; // Ajuste o namespace conforme necessário

namespace WCFServiceHost.Test
{
    class Test
    {
        static void Main() {
            // Use a declaração 'using' para garantir que o cliente seja fechado corretamente.
            using (var client = new ServiceClient.ServiceClient()) // Ajuste o namespace conforme necessário
            {
                try {
                    // Chamar a operação de obter clientes.
                    Cliente[] clientesArray = client.ObterClientes();

                    // Converter o array para uma lista.
                    List<Cliente> clientes = new List<Cliente>(clientesArray);

                    // Exibir os dados dos clientes.
                    foreach (var cliente in clientes) {
                        Console.WriteLine($"ID: {cliente.ClienteId}, Nome: {cliente.Nome}, CPF: {cliente.CPF}");
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine($"Erro ao chamar o serviço: {ex.Message}");
                }
            }
        }
    }
}
