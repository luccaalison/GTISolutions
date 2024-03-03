namespace WCFServiceHost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        CPF = c.String(unicode: false),
                        Nome = c.String(unicode: false),
                        RG = c.String(unicode: false),
                        DataExpedicao = c.DateTime(nullable: false, precision: 0),
                        OrgaoExpedicao = c.String(unicode: false),
                        UFExpedicao = c.String(unicode: false),
                        DataNascimento = c.DateTime(nullable: false, precision: 0),
                        Sexo = c.String(unicode: false),
                        EstadoCivil = c.String(unicode: false),
                        Endereco_EnderecoClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.EnderecoClientes", t => t.Endereco_EnderecoClienteId)
                .Index(t => t.Endereco_EnderecoClienteId);
            
            CreateTable(
                "dbo.EnderecoClientes",
                c => new
                    {
                        EnderecoClienteId = c.Int(nullable: false, identity: true),
                        CEP = c.String(unicode: false),
                        Logradouro = c.String(unicode: false),
                        Numero = c.String(unicode: false),
                        Complemento = c.String(unicode: false),
                        Bairro = c.String(unicode: false),
                        Cidade = c.String(unicode: false),
                        UF = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.EnderecoClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "Endereco_EnderecoClienteId", "dbo.EnderecoClientes");
            DropIndex("dbo.Clientes", new[] { "Endereco_EnderecoClienteId" });
            DropTable("dbo.EnderecoClientes");
            DropTable("dbo.Clientes");
        }
    }
}
