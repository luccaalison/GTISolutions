using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WCFServiceHost.Data;
using WCFServiceHost.Models;

namespace WCFServiceHost.Helpers
{
    public static class HelperBancoDeDados
    {
        public static List<Cliente> ObterClientes() {
            using (var contexto = new MyDbContext()) {
                return contexto.Clientes.Include(c => c.Endereco).ToList();
            }
        }

        public static void AdicionarCliente(Cliente cliente) {
            using (var contexto = new MyDbContext()) {
                contexto.Clientes.Add(cliente);
                contexto.SaveChanges();
            }
        }

        public static void EditarCliente(int clienteId, Cliente clienteAtualizado) {
            try {
                using (var contexto = new MyDbContext()) {
                    var clienteExistente = contexto.Clientes.Include(c => c.Endereco).SingleOrDefault(c => c.ClienteId == clienteId);

                    if (clienteExistente != null) {
                        Log.Information($"Cliente encontrado para edição. ID: {clienteExistente.ClienteId}");

                        contexto.Entry(clienteExistente).CurrentValues.SetValues(clienteAtualizado);

                        if (clienteExistente.Endereco != null && clienteAtualizado.Endereco != null) {
                            contexto.Entry(clienteExistente.Endereco).CurrentValues.SetValues(clienteAtualizado.Endereco);
                            Log.Information("Dados do endereço atualizados.");
                        }
                        else if (clienteExistente.Endereco == null && clienteAtualizado.Endereco != null) {
                            clienteExistente.Endereco = clienteAtualizado.Endereco;
                            Log.Information("Novo endereço associado ao cliente.");
                        }

                        contexto.SaveChanges();
                        Log.Information("Alterações salvas no banco de dados.");
                    }
                    else {
                        Log.Information("Cliente não encontrado para edição.");
                    }
                }
            }
            catch (Exception ex) {
                Log.Error($"Erro ao editar o cliente. Detalhes: {ex.Message}");
                throw; 
            }
        }

        public static void ExcluirCliente(int clienteId) {
            using (var contexto = new MyDbContext()) {
                var clienteParaExcluir = contexto.Clientes.Include(c => c.Endereco).SingleOrDefault(c => c.ClienteId == clienteId);

                if (clienteParaExcluir != null) {
                    contexto.Clientes.Remove(clienteParaExcluir);

                    if (clienteParaExcluir.Endereco != null) {
                        contexto.Entry(clienteParaExcluir.Endereco).State = EntityState.Deleted;
                    }

                    contexto.SaveChanges();
                }
            }
        }

        public static Cliente BuscarClientePorCPF(string cpf) {
            using (var contexto = new MyDbContext()) {
                return contexto.Clientes.Include(c => c.Endereco).FirstOrDefault(c => c.CPF == cpf);
            }
        }

    }
}