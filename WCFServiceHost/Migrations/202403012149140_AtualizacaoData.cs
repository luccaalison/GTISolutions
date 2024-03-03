namespace WCFServiceHost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizacaoData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "DataExpedicao", c => c.String(unicode: false));
            AlterColumn("dbo.Clientes", "DataNascimento", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "DataNascimento", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Clientes", "DataExpedicao", c => c.DateTime(precision: 0));
        }
    }
}
