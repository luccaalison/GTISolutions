using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
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