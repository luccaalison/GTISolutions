namespace WCFServiceHost.Migrations
{
    using MySql.Data.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Common;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    using WCFServiceHost.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }

        protected override void Seed(MyDbContext context) {
            // Adicione as operações de seed se necessário
        }
    }
}
