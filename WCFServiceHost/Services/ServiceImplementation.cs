using Serilog;
using System;
using System.Collections.Generic;
using WCFServiceHost.Contracts;
using WCFServiceHost.Helpers;
using WCFServiceHost.Models;

namespace WCFServiceHost.Services
{
    public class ServiceImplementation : IService
    {
        static ServiceImplementation() {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
                AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
        }
        public List<Cliente> ObterClientes() {
            return HelperBancoDeDados.ObterClientes();
        }

        public void AdicionarCliente(Cliente cliente) {
            HelperBancoDeDados.AdicionarCliente(cliente);
        }

        public void EditarCliente(int clienteId, Cliente clienteAtualizado) {
            Log.Information($"Início da operação de edição do cliente. ID: {clienteId}");

            try {
                HelperBancoDeDados.EditarCliente(clienteId, clienteAtualizado);
                Log.Information("Cliente editado com sucesso.");
            }
            catch (Exception ex) {
                Log.Error($"Erro ao editar o cliente. Detalhes: {ex.Message}");
                throw; // Re-throw a exceção para que ela seja propagada para o código cliente.
            }
        }

        public void ExcluirCliente(int clienteId) {
            HelperBancoDeDados.ExcluirCliente(clienteId);
        }

        public Cliente BuscarClientePorCPF(string cpf) {
            return HelperBancoDeDados.BuscarClientePorCPF(cpf);
        }
    }
}
