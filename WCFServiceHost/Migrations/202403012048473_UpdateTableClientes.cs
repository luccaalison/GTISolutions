namespace WCFServiceHost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableClientes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "DataExpedicao", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "DataExpedicao", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
