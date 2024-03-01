using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WCFServiceHost.Models;

namespace WCFServiceHost.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyDbContext") {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EnderecoCliente> EnderecosClientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Cliente>().HasKey(c => c.ClienteId);
            modelBuilder.Entity<EnderecoCliente>().HasKey(e => e.EnderecoClienteId);
        }
    }
}