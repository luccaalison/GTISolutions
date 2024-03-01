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
            using (var contexto = new MyDbContext()) {
                var clienteExistente = contexto.Clientes.Include(c => c.Endereco).SingleOrDefault(c => c.ClienteId == clienteId);

                if (clienteExistente != null) {
                    contexto.Entry(clienteExistente).CurrentValues.SetValues(clienteAtualizado);

                    if (clienteExistente.Endereco != null && clienteAtualizado.Endereco != null) {
                        contexto.Entry(clienteExistente.Endereco).CurrentValues.SetValues(clienteAtualizado.Endereco);
                    }

                    contexto.SaveChanges();
                }
            }
        }

        public static void ExcluirCliente(int clienteId) {
            using (var contexto = new MyDbContext()) {
                var clienteParaExcluir = contexto.Clientes.Find(clienteId);

                if (clienteParaExcluir != null) {
                    contexto.Clientes.Remove(clienteParaExcluir);
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