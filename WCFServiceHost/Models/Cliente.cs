using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WCFServiceHost.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public string RG { get; set; }

        public DateTime DataExpedicao { get; set; }

        public string OrgaoExpedicao { get; set; }

        public string UF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public string EstadoCivil { get; set; }

        public EnderecoCliente Endereco { get; set; }
    }
}